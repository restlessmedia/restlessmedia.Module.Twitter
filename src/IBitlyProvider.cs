namespace restlessmedia.Module.Twitter
{
  public interface IBitlyProvider : IProvider
  {
    string ShortenUrl(string login, string apiKey, string url);
  }
}