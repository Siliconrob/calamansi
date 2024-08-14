using calamansi.ServiceInterface.Utils;
using ServiceStack;
using calamansi.ServiceModel;

namespace calamansi.ServiceInterface;

public class CountriesServices : Service
{
    public async Task<object> Any(Countries request)
    {
        var countries = string.IsNullOrWhiteSpace(request.Code)
            ? await RequestProxy.GetCountries(Cache)
            : await RequestProxy.GetCountriesByCode(request.Code.Trim(), Cache);
        
        if (!string.IsNullOrWhiteSpace(request.Find))
        {
            countries = countries.SearchAll(request.Find.Trim());
        }        
        return countries.GetPagedResponse(new PageParams
        {
            Limit = request.Limit,
            Page = request.Page,
            SortBy = request.SortBy,
            SortDesc = request.SortDesc
        });
    }
}