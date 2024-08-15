using calamansi.ServiceModel.ProxyModels;
using ServiceStack;
using ServiceStack.Caching;

namespace calamansi.ServiceInterface.Utils;

public static class RequestProxy
{
    private const string BaseRestUrl = "https://restcountries.com/v3.1";

    private const string BaseKey = "countries";
    private static TimeSpan CacheTTL = TimeSpan.FromHours(8);
    
    public static async Task<List<Country>> GetCountriesByCode(string code, ICacheClient cache)
    {
        if (int.TryParse(code, out var parsed))
        {
            if (parsed < 100)
            {
                code = parsed.ToString("D3");
            }
        }
        
        var queryPath = $"/alpha/{code}";
        var cacheKey = $"{BaseKey}_{queryPath}";
        var results = cache?.Get<List<Country>>(cacheKey) ?? [];
        if (results.Count != 0)
        {
            return results;
        }
        using var client = new JsonServiceClient(BaseRestUrl);
        results = await client.GetAsync<List<Country>>(queryPath);
        cache?.Add(cacheKey, results, CacheTTL);
        return results;        
    }
    
    public static async Task<List<Country>> GetCountries(ICacheClient cache)
    {
        const string queryPath = "/all";
        const string cacheKey = $"{BaseKey}_{queryPath}";
        var results = cache?.Get<List<Country>>(cacheKey) ?? [];
        if (results.Count != 0)
        {
            return results;
        }
        using var client = new JsonServiceClient(BaseRestUrl);
        results = await client.GetAsync<List<Country>>(queryPath);
        cache?.Add(cacheKey, results, CacheTTL);
        return results;
    }
}

