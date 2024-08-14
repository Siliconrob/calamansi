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
    public async Task Can_call_MyServices()
    {
        var service = appHost.Container.Resolve<CountriesServices>();

        //var response = (CountriesResponse)service.Any(new Countries { Code = "World" });
        
        var response = await service.Any(new Countries { Code = "World" }) as CountriesResponse;

        Assert.That(response.Page, Is.EqualTo(1));
    }
}