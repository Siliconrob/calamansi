using calamansi.ServiceInterface.Utils;
using calamansi.ServiceModel;
using calamansi.ServiceModel.ProxyModels;
using ServiceStack;

namespace calamansi.ServiceInterface;

public class LanguagesServices : Service
{
    private static TimeSpan CacheTTL = TimeSpan.FromHours(8);
    
    public async Task<object> Any(Languages request)
    {
        var key = string.IsNullOrWhiteSpace(request.Id) ? request.CacheKey() : request.CacheKey(request.Id.Trim());
        var languages = Cache.Get<LanguagesResponse>(key);
        if (languages != null)
        {
            return languages;
        }
        var countries = await RequestProxy.GetCountries(Cache);
        var languagesKey = new Dictionary<string, List<Country>>().CacheKey("languageDict");
        var languagesDict = Cache.Get<Dictionary<string, List<Country>>>(languagesKey) ??  new Dictionary<string, List<Country>>();
        if (languagesDict.Count == 0)
        {
            //foreach (var currentCountryLanguages in countries.Select(z => z.Languages))
            foreach (var country in countries)
            {
                foreach (var item in country.Languages)
                {
                    var abbr = item.Key;
                    if (!languagesDict.TryGetValue(abbr, out var abbrValue))
                    {
                        languagesDict.Add(abbr, [country]);
                    }
                    else
                    {
                        abbrValue.Add(country);
                        languagesDict[abbr] = abbrValue.DistinctBy(z => z.Cca2).ToList();
                    }
                    // var full = item.Value.ToString();
                    // if (full == null)
                    // {
                    //     continue;
                    // }
                    // if (!languagesDict.TryGetValue(full, out var fullValue))
                    // {
                    //     languagesDict.Add(full, [country]);
                    // }
                    // else
                    // {
                    //     fullValue.Add(country);
                    //     languagesDict[full] = fullValue.DistinctBy(z => z.Cca2).ToList();
                    // }
                }
            }
        }

        if (languagesDict.Count == 0)
        {
            return new LanguagesResponse();
        }
        
        
        
        
        return new LanguagesResponse { Result = $"Hello, {request.Id}!" };
    }
}