using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/regions/{id}")]
public class Regions : PagedRequest, IGet, IReturn<PagedDictionaryResponse>
{
    public string Id { get; set; }
}
