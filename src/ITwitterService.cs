using restlessmedia.Module.Security;

namespace restlessmedia.Module.Twitter
{
  public interface ITwitterService
  {
    ModelCollection<Tweet> List(string username, int max = 1);

    IOAuthTokens GetTokens(string username);

    void UpdateStatus(string username, string status);

    void UpdateStatus(string username, string status, string url);

    Tweet Latest(string username);
  }
}
