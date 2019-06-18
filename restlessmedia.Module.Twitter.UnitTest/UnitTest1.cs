using Autofac;
using Xunit;

namespace restlessmedia.Module.Twitter.UnitTest
{
  public class UnitTest1
  {
    [Fact(Skip = "How can we test the component gets registered correctly?")]
    public void TestMethod1()
    {
      Module module = new Module();
      ContainerBuilder containerBuilder = new ContainerBuilder();
      module.RegisterComponents(containerBuilder);
    }
  }
}