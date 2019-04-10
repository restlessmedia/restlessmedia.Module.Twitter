using Autofac;
using restlessmedia.Module.Twitter.Configuration;

namespace restlessmedia.Module.Twitter
{
  internal class Module : IModule
  {
    public void RegisterComponents(ContainerBuilder containerBuilder)
    {
      containerBuilder.RegisterSettings<IBitlySettings>("restlessmedia/bitly", required: false);
      containerBuilder.RegisterType<BirdFeedProvider>().As<ITwitterProvider>().SingleInstance();
      containerBuilder.RegisterType<BitlyProvider>().As<IBitlyProvider>().SingleInstance();
      containerBuilder.Register(x =>
      {
        if (x.TryResolve(out IBitlySettings bitlySettings))
        {
          return new BitlyService(bitlySettings, x.Resolve<IBitlyProvider>());
        }

        return null;
      }).As<IBitlyService>().SingleInstance();
      containerBuilder.RegisterType<TwitterService>().As<ITwitterService>().SingleInstance();
    }
  }
}