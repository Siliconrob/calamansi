using calamansi.ServiceInterface.Utils;
using calamansi.ServiceModel;
using ServiceStack;

namespace calamansi.ServiceInterface;

public class LanguagesServices : Service
{
    
    public async Task<object> Any(Languages request)
    {
        var key = string.IsNullOrWhiteSpace(request.Id) ? request.CacheKey() : request.CacheKey(request.Id.Trim());
        var languages = Cache.Get<PagedDictionaryResponse>(key);
        if (languages != null)
        {
            return languages;
        }
        var countries = await RequestProxy.GetCountries(Cache);
        if (!string.IsNullOrWhiteSpace(request.Id))
        {
            var dict = DictionaryBuilder.ByLanguages(countries);
            var search = request.Id.Trim().ToLowerInvariant();
            if (dict.TryGetValue(search, out var matched))
            {
                return new ItemResponse
                {
                    Name = search,
                    Countries = matched.OrderByDynamic(request.SortBy, !request.SortDesc).ToList()
                };
            }
        }
        if (!string.IsNullOrWhiteSpace(request.Find))
        {
            countries = countries.SearchAll(request.Find.Trim());
        }
        var all = DictionaryBuilder.ByLanguages(countries.OrderByDynamic(request.SortBy, !request.SortDesc).ToList());
        var (q,r) = Math.DivRem(all.Count, request.Limit);
        var skip = (request.Page - 1) * request.Limit;
        var pageResults = all.Skip(skip).Take(request.Limit).ToDictionary();
        return new PagedDictionaryResponse
        {
            Items = pageResults.Values,
            ItemCount = pageResults.Count,
            Page = request.Page,
            PageCount =  r > 0 ? q + 1 : q,
            Total = all.Count
        };
    }
}