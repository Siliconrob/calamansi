using calamansi.ServiceModel;
using ServiceStack;

namespace calamansi.ServiceInterface;

public class RegionsServices : Service
{
    public object Any(Regions request)
    {
        return new RegionsResponse { Result = $"Hello, {request.Id}!" };
    }
}