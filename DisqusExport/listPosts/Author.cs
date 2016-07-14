using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqusExport.listPosts
{
    public class Author
    {
        public bool isFollowing { get; set; }
        public bool disable3rdPartyTrackers { get; set; }
        public bool isPowerContributor { get; set; }
        public bool isFollowedBy { get; set; }
        public bool isPrimary { get; set; }
        public string id { get; set; }
        public float rep { get; set; }
        public string emailHash { get; set; }
        public string location { get; set; }
        public bool isPrivate { get; set; }
        public DateTime joinedAt { get; set; }
        public string email { get; set; }
        public bool isVerified { get; set; }
        public string username { get; set; }
        public string about { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string profileUrl { get; set; }
        public float reputation { get; set; }
        public Avatar avatar { get; set; }
        public string signedUrl { get; set; }
        public bool isAnonymous { get; set; }
        public bool homeOnboardingComplete { get; set; }
        public bool flaggedForSpamReview { get; set; }
        public bool homeFeedOnboardingComplete { get; set; }
    }
}
