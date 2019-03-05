using BitlyDotNET.Interfaces;

namespace restlessmedia.Module.Twitter
{
  internal class BitlyProvider : IBitlyProvider
  {
    public bool ShortenUrl(string login, string apiKey, string url, out string shortenedUrl)
    {
      BitlyDotNET.Interfaces.IBitlyService service = new BitlyDotNET.Implementations.BitlyService(login, apiKey);
      bool success = service.Shorten(url, out shortenedUrl) == StatusCode.OK;
      return success;
    }

    public string ShortenUrl(string login, string apiKey, string url)
    {
      // if the shorten service fails, just return the full url
      return ShortenUrl(login, apiKey, url, out string shortenedUrl) ? shortenedUrl : url;
    }
  }
}