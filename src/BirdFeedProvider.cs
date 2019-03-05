using restlessmedia.Module.Security;
using System.Linq;

namespace restlessmedia.Module.Twitter
{
  public class BirdFeedProvider : ITwitterProvider
  {
    public ModelCollection<Tweet> List(IOAuthTokens tokens, string username, int max = 1)
    {
      return new ModelCollection<Tweet>(Create(tokens).Tweets(username, max).Select(x => new Tweet
      {
        Status = x.Html
      }));
    }

    public void UpdateStatus(IOAuthTokens tokens, string username, string status)
    {
      Create(tokens).Tweet(status);
    }

    private BirdFeed.Core.ITwitter Create(IOAuthTokens tokens)
    {
      BirdFeed.Core.IAuthCredentials auth = new BirdFeed.Core.AuthCredentials(tokens.ConsumerKey, tokens.ConsumerSecret, tokens.AccessToken, tokens.AccessTokenSecret);
      return BirdFeed.Core.BirdFeeder.Create(auth);
    }
  }
}