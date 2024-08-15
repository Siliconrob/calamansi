using calamansi.ServiceModel;
using calamansi.ServiceModel.ProxyModels;

namespace calamansi.ServiceInterface.Utils;

public static class PagedResultCreator
{
    public static CountriesResponse GetPagedResponse(this List<Country> countries, PageParams pageRequest)
    {
        if (string.IsNullOrWhiteSpace(pageRequest.SortBy))
        {
            pageRequest.SortBy = "cca2";
        }
        countries = countries.OrderByDynamic(pageRequest.SortBy.Trim(), !pageRequest.SortDesc).ToList();
        
        var (q,r) = Math.DivRem(countries.Count, pageRequest.Limit);
        var skip = (pageRequest.Page - 1) * pageRequest.Limit;
        var pageResults = countries.Skip(skip).Take(pageRequest.Limit).ToList();
        return new CountriesResponse
        {
            Items = pageResults,
            ItemCount = pageResults.Count,
            Page = pageRequest.Page,
            PageCount =  r > 0 ? q + 1 : q,
            Total = countries.Count
        };
    }
}

public class PageParams
{
    public string SortBy { get; set; }
    public int Page { get; set; }
    public int Limit { get; set; }
    public bool SortDesc { get; set; }
}