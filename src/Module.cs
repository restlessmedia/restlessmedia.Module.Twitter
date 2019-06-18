using Autofac;
using Autofac.Core;
using restlessmedia.Module.Security;
using restlessmedia.Module.Security.Data;
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
      containerBuilder.RegisterType<BitlyService>().As<IBitlyService>().SingleInstance();

      // TODO: refactor this to be better
      // we are registering with a different ctor depending
      // on whether the IBitlySettings has been provided or not

      containerBuilder.Register(x => new TwitterService(x.Resolve<ITwitterProvider>(), x.Resolve<IAuthService>(), x.Resolve<IBitlyService>(), x.Resolve<ISecurityDataProvider>()))
        .OnlyIf(x => x.IsRegistered(new TypedService(typeof(IBitlySettings))))
        .As<ITwitterService>()
        .SingleInstance();

      containerBuilder.Register(x => new TwitterService(x.Resolve<ITwitterProvider>(), x.Resolve<IAuthService>(), x.Resolve<ISecurityDataProvider>()))
        .OnlyIf(x => !x.IsRegistered(new TypedService(typeof(IBitlySettings))))
        .As<ITwitterService>()
        .SingleInstance();
    }
  }
}