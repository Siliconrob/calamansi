using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/countries/{code}")]
public class Countries : IGet, IReturn<CountriesResponse>
{
    public string Code { get; set; }
}

public class CountriesResponse
{
    public required string Result { get; set; }
}