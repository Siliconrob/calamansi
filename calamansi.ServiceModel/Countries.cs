using calamansi.ServiceModel.ProxyModels;
using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/countries/{code}")]
public class Countries : PagedRequest, IGet, IReturn<CountriesResponse>
{
    [ApiMember(Name = "code",
        Description = "Search by country code: default is (empty), in OpenAPI interactive fill with `\"\"`",
        ParameterType = "path",
        DataType = "string"
    )]
    public string Code { get; set; } = "";
}

public class CountriesResponse
{
    public required List<Country> Items { get; set; }
    public required int ItemCount { get; set; }
    public required int Page { get; set; }
    public required int PageCount { get; set; }
    public required int Total { get; set; }
}