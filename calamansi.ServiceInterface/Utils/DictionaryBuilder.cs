using calamansi.ServiceModel.ProxyModels;

namespace calamansi.ServiceInterface.Utils;

public static class DictionaryBuilder
{
    public static Dictionary<string, List<Country>> ByRegions(List<Country> countries)
    {
        var regions = countries.Select(z => z.Region.ToLowerInvariant())
            .Distinct()
            .ToList();

        var languagesDict =
            regions.ToDictionary(region => region,
                region => countries.Where(z => z.Region.ToLowerInvariant() == region)
                    .ToList());
        
        return languagesDict;
    }    
    
    public static Dictionary<string, List<Country>> ByLanguages(List<Country> countries)
    {
        var languagesDict = new Dictionary<string, List<Country>>();
        foreach (var country in countries)
        {
            var languages = country.Languages ?? new Dictionary<string, object>();
            foreach (var abbr in languages.Select(item => item.Key.ToLowerInvariant()))
            {
                if (!languagesDict.TryGetValue(abbr, out var abbrValue))
                {
                    languagesDict.Add(abbr, [country]);
                }
                else
                {
                    abbrValue.Add(country);
                    languagesDict[abbr] = abbrValue.DistinctBy(z => z.Cca2).ToList();
                }
            }
        }
        return languagesDict;
    }    
}