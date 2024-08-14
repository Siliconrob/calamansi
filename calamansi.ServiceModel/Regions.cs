using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/regions/{id}")]
public class Regions : PagedRequest, IGet, IReturn<RegionsResponse>
{
    public string Id { get; set; }
}

public class RegionsResponse
{
    public required string Result { get; set; }
}