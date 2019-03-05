using Autofac;
using restlessmedia.Module.Twitter.Configuration;

namespace restlessmedia.Module.Twitter
{
  internal class Module : IModule
  {
    public void RegisterComponents(ContainerBuilder containerBuilder)
    {
      containerBuilder.RegisterSettings<IBitlySettings>("restlessmedia/bitly", required: true);
      containerBuilder.RegisterType<BirdFeedProvider>().As<ITwitterProvider>().SingleInstance(); 
      containerBuilder.RegisterType<BitlyProvider>().As<IBitlyProvider>().SingleInstance();
      containerBuilder.RegisterType<BitlyService>().As<IBitlyService>().SingleInstance();
      containerBuilder.RegisterType<TwitterService>().As<ITwitterService>().SingleInstance();
    }
  }
}