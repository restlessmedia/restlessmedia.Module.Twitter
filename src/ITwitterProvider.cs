using restlessmedia.Module.Security;

namespace restlessmedia.Module.Twitter
{
  internal interface ITwitterProvider : IProvider
  {
    ModelCollection<Tweet> List(IOAuthTokens tokens, string username, int max = 1);

    void UpdateStatus(IOAuthTokens tokens, string username, string status);
  }
}