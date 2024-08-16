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
        var pageReq = new PageParams
        {
            Limit = request.Limit,
            Page = request.Page,
            SortBy = request.Sort_By,
            SortDesc = request.Sort_Desc
        };
        return countries.SortCountries(pageReq).GetPagedResponse(pageReq);
    }
}