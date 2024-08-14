using calamansi.ServiceModel;
using ServiceStack;

namespace calamansi.ServiceInterface;

public class LanguagesServices : Service
{
    public object Any(Languages request)
    {
        return new LanguagesResponse { Result = $"Hello, {request.Id}!" };
    }
}