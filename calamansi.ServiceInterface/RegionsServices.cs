using calamansi.ServiceInterface.Utils;
using calamansi.ServiceModel;
using calamansi.ServiceModel.ProxyModels;
using ServiceStack;

namespace calamansi.ServiceInterface;

public class RegionsServices : Service
{
    public async Task<object> Any(Regions request)
    {
        var sorter = new PageParams
        {
            SortBy = request.Sort_By,
            SortDesc = request.Sort_Desc
        };
        var countries = await RequestProxy.GetCountries(Cache);
        if (!string.IsNullOrWhiteSpace(request.Id))
        {
            var dict = DictionaryBuilder.ByRegions(countries);
            var search = request.Id.Trim().ToLowerInvariant();
            if (dict.TryGetValue(search, out var matched))
            {
                return new ItemResponse
                {
                    Name = search,
                    Countries = matched.SortCountries(sorter).ToList()
                };
            }
        }
        if (!string.IsNullOrWhiteSpace(request.Find))
        {
            countries = countries.SearchAll(request.Find.Trim());
        }
        
        var all = DictionaryBuilder.ByRegions(countries)
            .OrderBy(z => z.Key)
            .ToDictionary(f => f.Key, f => f.Value.SortCountries(sorter));

        var (q, r) = Math.DivRem(all.Count, request.Limit);
        var skip = (request.Page - 1) * request.Limit;
        var pageResults = all.Skip(skip).Take(request.Limit).ToDictionary();

        return new RegionsResponse
        {
            Items = pageResults.Select(z => new RegionResponseItem
            {
                Region = z.Key,
                Items = z.Value
            }).ToList(),
            ItemCount = pageResults.Count,
            Page = request.Page,
            PageCount = r > 0 ? q + 1 : q,
            Total = all.Count
        };
    }
}