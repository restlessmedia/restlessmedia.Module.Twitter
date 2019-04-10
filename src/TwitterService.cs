using restlessmedia.Module.Security;
using restlessmedia.Module.Security.Data;
using System;
using System.Linq;

namespace restlessmedia.Module.Twitter
{
  internal class TwitterService : ITwitterService
  {
    public TwitterService(ITwitterProvider twitterProvider, IAuthService authService, IBitlyService bitlyService, ISecurityDataProvider securityDataProvider)
    {
      _twitterProvider = twitterProvider ?? throw new ArgumentNullException(nameof(twitterProvider));
      _authService = authService ?? throw new ArgumentNullException(nameof(authService));
      _bitlyService = bitlyService;
      _securityDataProvider = securityDataProvider ?? throw new ArgumentNullException(nameof(securityDataProvider));
    }

    public ModelCollection<Tweet> List(string username, int max = 1)
    {
      IOAuthTokens tokens = GetTokens(username);
      return _twitterProvider.List(tokens, username, max);
    }

    public IOAuthTokens GetTokens(string username)
    {
      return _securityDataProvider.ReadAuth(AuthServiceType.Twitter, username);
    }

    public void UpdateStatus(string username, string status)
    {
      IOAuthTokens tokens = _authService.Read(AuthServiceType.Twitter, username);
      _twitterProvider.UpdateStatus(tokens, username, status);
    }

    public void UpdateStatus(string username, string status, string url)
    {
      string shortUrl = _bitlyService != null ? _bitlyService.ShortenUrl(url) : url;
      string sep = "... ";

      if (!string.IsNullOrEmpty(shortUrl))
      {
        int titleLength = _tweetLength - shortUrl.Length - sep.Length;
        status = string.Concat(status.Length > titleLength ? status.Substring(0, titleLength) : status, sep, shortUrl);
      }
      else if (status.Length > _tweetLength)
      {
        status = string.Concat(status.Substring(0, _tweetLength - sep.Length), sep);
      }

      UpdateStatus(username, status);
    }

    public Tweet Latest(string username)
    {
      return List(username, 1).FirstOrDefault();
    }

    private const int _tweetLength = 140;

    private readonly ITwitterProvider _twitterProvider;

    private readonly IBitlyService _bitlyService;

    private readonly IAuthService _authService;

    private readonly ISecurityDataProvider _securityDataProvider;
  }
}