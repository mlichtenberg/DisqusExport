# DisqusExport
C# console app for backing up the content in your Disqus forums.

This application downloads all forums, threads, and posts for a Disqus account owner.  It is
similar to the existing Disqus Export functionality (and API), except it downloads the data
directly rather than sending it to the Disqus account owner's email account.  In addition,
this application can be modified to include more information than the Disqus-provided exports.

The application authenticates as a Disqus account owner by simply passing the Access Token that
is associated with the Disqus account.  This token authenticates the app as the account owner and
does not expire.  It is obtained by logging into the Disqus account owner's account at disqus.com.
For more details see the page https://disqus.com/api/docs/auth/, especially the section titled
"Authenticating as the Account Owner".

NOTE: In order for certain data (such as IP Addresses and Email Addresses) to be available via
the APIs, the Access Token must have the following Permissions: Read, Write, Manage Forums

To use the application as-is, simply add a valid Disqus Public Key and Access Token to the
app.config file.
