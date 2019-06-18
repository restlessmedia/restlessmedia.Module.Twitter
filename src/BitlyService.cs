using restlessmedia.Module.Twitter.Configuration;
using System;

namespace restlessmedia.Module.Twitter
{
  internal class BitlyService : IBitlyService
  {
    public BitlyService(IBitlySettings settings, IBitlyProvider bitlyProvider)
      : this(bitlyProvider)
    {
      _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }

    public BitlyService(IBitlyProvider bitlyProvider)
    {
      _bitlyProvider = bitlyProvider ?? throw new ArgumentNullException(nameof(bitlyProvider));
    }

    private BitlyService() { }

    public string ShortenUrl(string url)
    {
      if (_settings == null)
      {
        return url;
      }

      if (string.IsNullOrEmpty(url))
      {
        throw new ArgumentNullException(nameof(url), "ShortenUrl requires a valid url");
      }

      if (url.IndexOf("localhost", StringComparison.OrdinalIgnoreCase) > -1)
      {
        throw new NotSupportedException("Url shorterning for localhost is not supported");
      }

      return _bitlyProvider.ShortenUrl(_settings.Login, _settings.ApiKey, url);
    }

    public static BitlyService Disabled = new BitlyService();

    private readonly IBitlyProvider _bitlyProvider;

    private readonly IBitlySettings _settings;
  }
}