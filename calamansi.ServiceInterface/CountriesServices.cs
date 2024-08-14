using ServiceStack;
using calamansi.ServiceModel;

namespace calamansi.ServiceInterface;

public class CountriesServices : Service
{
    public object Any(Countries request)
    {
        return new CountriesResponse { Result = $"Hello, {request.Code}!" };
    }
}