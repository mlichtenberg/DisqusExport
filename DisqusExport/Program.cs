using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace DisqusExport
{
    class Program
    {
        // DISQUS API DOCS:  https://disqus.com/api/docs/

        // MULTIPLE APP.CONFIG DOCS: https://mitasoft.wordpress.com/2011/09/28/multipleappconfig/

        static void Main(string[] args)
        {
            List<output.disqus> disqusOutputList = new List<output.disqus>();

            try
            {
                // Read forum id from the command line (if one has been specified)
                string forumId = GetForumIdFromCommandLine();

                // Harvest the list of forums
                if (!string.IsNullOrWhiteSpace(forumId))
                    disqusOutputList = HarvestForum(forumId);
                else
                    disqusOutputList = HarvestForums();

                // Harvest the data from each forum
                foreach (output.disqus disqusOutput in disqusOutputList)
                {
                    // Harvest the threads for the forum
                    HarvestThreads(disqusOutput);

                    // Harvest the posts for a forum
                    HarvestPosts(disqusOutput);
                }

                // Serialize all of the data to XML and save it
                XmlSerializer serializer = new XmlSerializer(typeof(List<output.disqus>));
                StreamWriter sw = new StreamWriter(string.Format("DisqusExport{0}.xml", forumId));
                serializer.Serialize(sw, disqusOutputList);
                sw.Close();

                // Serialize all of the data to JSON and save it
                string jsonOutput = JsonConvert.SerializeObject(disqusOutputList);
                File.WriteAllText(string.Format("DisqusExport{0}.json", forumId), jsonOutput);
            }
            catch (Exception ex)
            {
                OutputExceptionDetails(ex);
            }
            finally
            {
                OutputStats(disqusOutputList);
            }
        }

        /// <summary>
        /// Get the list of forums
        /// </summary>
        /// <param name="disqusOutputList"></param>
        static List<output.disqus> HarvestForums()
        {
            List<output.disqus> disqusOutputList = new List<output.disqus>();

            listForums.Rootobject listForumsResponse = null;
            string cursor = string.Empty;
            do
            {
                // Call users/listForums to get the next page of forums
                Dictionary<string, string> APIParameters = new Dictionary<string, string>();
                APIParameters.Add("limit", "100");
                if (!string.IsNullOrWhiteSpace(cursor)) APIParameters.Add("cursor", cursor);
                IRestResponse jsonResponse = DisqusCall("users/listForums", Method.GET, APIParameters);

                // Parse the results into a list
                listForumsResponse = JsonConvert.DeserializeObject<listForums.Rootobject>(jsonResponse.Content);
                cursor = listForumsResponse.cursor.id;
                foreach (listForums.Response forumResponse in listForumsResponse.response)
                {
                    output.disqus disqusOutput = new output.disqus();
                    output.disqusForum forum = new output.disqusForum();
                    forum.id = forumResponse.id;
                    forum.name = forumResponse.name;
                    forum.url = forumResponse.url;
                    disqusOutput.forum = forum;
                    disqusOutputList.Add(disqusOutput);
                }
            } while (listForumsResponse.cursor.hasNext);

            return disqusOutputList;
        }

        /// <summary>
        /// Get a single forum
        /// </summary>
        /// <param name="disqusOutputList"></param>
        static List<output.disqus> HarvestForum(string forumId)
        {
            List<output.disqus> disqusOutputList = new List<output.disqus>();

            forumDetails.Rootobject forumDetailsResponse = null;

            // Call users/listForums to get the next page of forums
            Dictionary<string, string> APIParameters = new Dictionary<string, string>();
            APIParameters.Add("forum", forumId);
            IRestResponse jsonResponse = DisqusCall("forums/details", Method.GET, APIParameters);

            // Parse the results into a list
            forumDetailsResponse = JsonConvert.DeserializeObject<forumDetails.Rootobject>(jsonResponse.Content);
            if (forumDetailsResponse.response != null)
            {
                output.disqus disqusOutput = new output.disqus();
                output.disqusForum forum = new output.disqusForum();
                forum.id = forumDetailsResponse.response.id;
                forum.name = forumDetailsResponse.response.name;
                forum.url = forumDetailsResponse.response.url;
                disqusOutput.forum = forum;
                disqusOutputList.Add(disqusOutput);
            }

            return disqusOutputList;
        }

        /// <summary>
        /// Get the threads for a forum
        /// </summary>
        /// <param name="disqusOutput"></param>
        static void HarvestThreads(output.disqus disqusOutput)
        {
            listThreads.Rootobject listThreadsResponse = null;
            List<output.disqusThread> threads = new List<output.disqusThread>();
            string cursor = string.Empty;
            do
            {
                // Call forums/listThreads to get the threads for each forum
                Dictionary<string, string> APIParameters = new Dictionary<string, string>();
                APIParameters.Add("forum", disqusOutput.forum.id);
                APIParameters.Add("limit", "100");
                if (!string.IsNullOrWhiteSpace(cursor)) APIParameters.Add("cursor", cursor);
                IRestResponse jsonResponse = DisqusCall("forums/listThreads", Method.GET, APIParameters);

                // Parse the results into a list
                listThreadsResponse = JsonConvert.DeserializeObject<listThreads.Rootobject>(jsonResponse.Content);
                cursor = listThreadsResponse.cursor.id;

                foreach (listThreads.Response threadsResponse in listThreadsResponse.response)
                {
                    output.disqusThread thread = new output.disqusThread();
                    thread.id = threadsResponse.id;
                    thread.identifier = threadsResponse.identifiers[0];
                    thread.forum = threadsResponse.forum;
                    thread.link = threadsResponse.link;
                    thread.feed = threadsResponse.feed;
                    thread.title = threadsResponse.title;
                    thread.slug = threadsResponse.slug;
                    thread.message = threadsResponse.message;
                    thread.createdAt = threadsResponse.createdAt;
                    thread.isClosed = threadsResponse.isClosed;
                    //thread.ipAddress = threadsResponse.ipAddress;
                    threads.Add(thread);
                }
            } while (listThreadsResponse.cursor.hasNext);

            disqusOutput.thread = threads.ToArray<output.disqusThread>();
        }

        /// <summary>
        /// Get the posts for a forum
        /// </summary>
        /// <param name="disqusOutput"></param>
        static void HarvestPosts(output.disqus disqusOutput)
        {
            listPosts.Rootobject listPostsResponse = null;
            List<output.disqusPost> posts = new List<output.disqusPost>();
            string cursor = string.Empty;
            do
            {
                // Call forums/listPosts to get the posts for each forum
                Dictionary<string, string> APIParameters = new Dictionary<string, string>();
                APIParameters.Add("forum", disqusOutput.forum.id);
                APIParameters.Add("limit", "100");
                if (!string.IsNullOrWhiteSpace(cursor)) APIParameters.Add("cursor", cursor);
                IRestResponse jsonResponse = DisqusCall("forums/listPosts", Method.GET, APIParameters);

                // Parse the results into a list
                listPostsResponse = JsonConvert.DeserializeObject<listPosts.Rootobject>(jsonResponse.Content);
                cursor = listPostsResponse.cursor.id;

                foreach (listPosts.Response threadPost in listPostsResponse.response)
                {
                    output.disqusPost post = new output.disqusPost();
                    post.id = threadPost.id;
                    post.message = threadPost.message;
                    post.raw_message = threadPost.raw_message;
                    post.createdAt = threadPost.createdAt;
                    post.isDeleted = threadPost.isDeleted;
                    post.isSpam = threadPost.isSpam;
                    //post.ipAddress = threadPost.ipAddress;
                    post.parent = threadPost.parent;

                    output.disqusPostThread postThread = new output.disqusPostThread();
                    postThread.id = Convert.ToUInt64(threadPost.thread);
                    post.thread = postThread;

                    output.disqusThread thread = (from t in disqusOutput.thread.ToList<output.disqusThread>()
                                                  where t.id == post.thread.id.ToString()
                                                  select t).FirstOrDefault();
                    if (thread != null) post.link = string.Format(ConfigurationManager.AppSettings["DisqusPostUrlFormat"],
                        threadPost.forum, thread.slug, post.id);

                    output.disqusPostAuthor postAuthor = new output.disqusPostAuthor();
                    postAuthor.username = threadPost.author.username;
                    postAuthor.name = threadPost.author.name;
                    postAuthor.id = threadPost.author.id;
                    postAuthor.email = threadPost.author.email;
                    post.author = postAuthor;

                    posts.Add(post);
                }
            } while (listPostsResponse.cursor.hasNext);

            disqusOutput.post = posts.ToArray<output.disqusPost>();
        }

        /// <summary>
        /// Perform a disqus API call
        /// </summary>
        /// <param name="APIPath"></param>
        /// <param name="APIMethod"></param>
        /// <param name="APIParameters"></param>
        /// <returns></returns>
        static IRestResponse DisqusCall(String APIPath, Method APIMethod, Dictionary<String, String> APIParameters)
        {
            // Wait four seconds before issuing a call to the Disqus API.  The API has a 1000-calls-per-hour 
            // rate limit.  Therefore, if more than 1000 calls are needed, then calls should be issued no
            // more frequently than one every 3.6 seconds.
            Thread.Sleep(4000);

            // This application is authenticating as a Disqus account owner by simply passing the Access Token
            // that is associated with the account.  This token authenticates the app as the account owner and
            // does not expire.  It is obtained by logging into the Disqus account owner's account at disqus.com.
            // For more details see the page https://disqus.com/api/docs/auth/, especially the section titled
            // "Authenticating as the Account Owner".
            //
            // NOTE: In order for certain data (such as IP Addresses and Email Addresses) to be available via
            // the APIs, the Access Token must have the following Permissions: Read, Write, Manage Forums
            //
            var disqus = new RestClient("https://disqus.com");
            var request = new RestRequest("/api/3.0/" + APIPath, APIMethod);
            request.AddParameter("api_key", ConfigurationManager.AppSettings["DisqusPublicKey"]);
            request.AddParameter("access_token", ConfigurationManager.AppSettings["DisqusAccessToken"]);
            foreach (KeyValuePair<String, String> parameter in APIParameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
            IRestResponse response = disqus.Execute(request);

            return response;
        }

        static string GetForumIdFromCommandLine()
        {
            string forumId = string.Empty;

            string[] args = System.Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                forumId = args[1];
            }

            return forumId;
        }

        /// <summary>
        /// Output exception details to the console
        /// </summary>
        /// <param name="ex"></param>
        static void OutputExceptionDetails(Exception ex)
        {
            try {
                // Build the message to log
                StringBuilder sb = new StringBuilder();
                if (ex.InnerException != null)
                {
                    sb.Append("Inner Exception Type: ");
                    sb.AppendLine(ex.InnerException.GetType().ToString());
                    sb.Append("Inner Exception: ");
                    sb.AppendLine(ex.InnerException.Message);
                    sb.Append("Inner Source: ");
                    sb.AppendLine(ex.InnerException.Source);
                    if (ex.InnerException.StackTrace != null)
                    {
                        sb.AppendLine("Inner Stack Trace: ");
                        sb.AppendLine(ex.InnerException.StackTrace);
                    }
                }
                sb.Append("Exception Type: ");
                sb.AppendLine(ex.GetType().ToString());
                sb.AppendLine("Exception: " + ex.Message);
                sb.AppendLine("Stack Trace: ");
                if (ex.StackTrace != null)
                {
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine();
                }

                Console.WriteLine();
                Console.WriteLine(sb.ToString());
                Console.WriteLine();
            }
            catch
            {
                // Ignore exceptions reporting an exception
            }
        }
        
        /// <summary>
        /// Output the export statistics
        /// </summary>
        static void OutputStats(List<output.disqus> disqusOutputList)
        {
            int forumCount = 0;
            int threadCount = 0;
            int postCount = 0;

            Console.WriteLine();
            Console.WriteLine("INDIVIDUAL FORUM STATS");
            Console.WriteLine();
            foreach(output.disqus output in disqusOutputList)
            {
                Console.WriteLine(string.Format("Forum:{0}\tThreads:{1}\tPosts:{2}", 
                    output.forum.id, 
                    output.thread.Count().ToString(), 
                    output.post.Count().ToString()));

                forumCount++;
                threadCount += output.thread.Count();
                postCount += output.post.Count();
            }
            Console.WriteLine();
            Console.WriteLine("TOTALS");
            Console.WriteLine();
            Console.WriteLine(string.Format("Forums:{0}\tThreads:{1}\tPosts:{2}",
                forumCount,
                threadCount,
                postCount));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
