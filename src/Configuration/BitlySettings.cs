using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;

namespace restlessmedia.Module.Twitter.Configuration
{
  internal class BitlySettings : SerializableConfigurationSection, IBitlySettings
  {
    [ConfigurationProperty(_loginProperty, IsRequired = true)]
    public string Login
    {
      get
      {
        return (string)this[_loginProperty];
      }
    }

    [ConfigurationProperty(_apiKeyProperty, IsRequired = true)]
    public string ApiKey
    {
      get
      {
        return (string)this[_apiKeyProperty];
      }
    }

    private const string _loginProperty = "login";

    private const string _apiKeyProperty = "apiKey";
  }
}