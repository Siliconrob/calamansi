using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using calamansi.ServiceInterface;
using calamansi.ServiceModel;

namespace calamansi.Tests;

public class UnitTest
{
    private readonly ServiceStackHost appHost;

    public UnitTest()
    {
        appHost = new BasicAppHost().Init();
        appHost.Container.AddTransient<CountriesServices>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    [Test]
    public void Can_call_MyServices()
    {
        var service = appHost.Container.Resolve<CountriesServices>();

        var response = (CountriesResponse)service.Any(new Countries { Code = "World" });

        Assert.That(response.Result, Is.EqualTo("Hello, World!"));
    }
}