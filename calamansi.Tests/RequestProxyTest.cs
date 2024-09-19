using calamansi.ServiceInterface.Utils;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using ServiceStack.Caching;

namespace calamansi.Tests;

public class RequestProxyTest
{
    private readonly ICacheClient cache = new MemoryCacheClient();

    [OneTimeTearDown]
    public void OneTimeTearDown() => cache.Dispose();
    
    [Test]
    public async Task MakeCountryProxyRequestTest()
    {
        foreach (var index in Enumerable.Range(0, 2))
        {
            var countries = await RequestProxy.GetCountries(cache);
            ClassicAssert.IsNotEmpty(countries);
            var country = countries.FirstOrDefault();
            ClassicAssert.NotNull(country);
            await TestContext.Out.WriteLineAsync(country?.Cca2);
        }
    }

    [Test]
    public async Task ByRegionsTest()
    {
        var countries = await RequestProxy.GetCountries(cache);
        ClassicAssert.IsNotEmpty(countries);
        var first = countries.FirstOrDefault();
        await TestContext.Out.WriteLineAsync(first?.Name);
        var dict = DictionaryBuilder.ByRegions(countries);
        foreach (var (key, value) in dict)
        {
            await TestContext.Out.WriteLineAsync($"{key}:{value.Count}");
        }
        ClassicAssert.True(dict.ContainsKey("Americas".ToLowerInvariant()));
    }    
    
    [Test]
    public async Task ByLanguagesTest()
    {
        var countries = await RequestProxy.GetCountries(cache);
        ClassicAssert.IsNotEmpty(countries);
        var first = countries.FirstOrDefault();
        await TestContext.Out.WriteLineAsync(first?.Name);
        var dict = DictionaryBuilder.ByLanguages(countries);
        foreach (var (key, value) in dict)
        {
            await TestContext.Out.WriteLineAsync($"{key}:{value.Count}");
        }
        ClassicAssert.True(dict.ContainsKey("eng".ToLowerInvariant()));
    }
    
    [Test]
    public async Task OrderByTest()
    {
        var countries = await RequestProxy.GetCountries(cache);
        ClassicAssert.IsNotEmpty(countries);
        var first = countries.FirstOrDefault();
        await TestContext.Out.WriteLineAsync(first.Name);
        countries = countries.OrderByDynamic("cca2").ToList();
        var firstOrdered = countries.FirstOrDefault();
        await TestContext.Out.WriteLineAsync(firstOrdered.Name);
    }
    
    
    [Test]
    public async Task FlattenTest()
    {
        var countries = await RequestProxy.GetCountries(cache);
        ClassicAssert.IsNotEmpty(countries);
        var matches = countries.SearchAll("Georgia");
        ClassicAssert.IsNotEmpty(matches);
        ClassicAssert.AreEqual(matches.Count, 2);
        foreach (var match in matches)
        {
            await TestContext.Out.WriteLineAsync(match.Name);   
        }
    }
    
}