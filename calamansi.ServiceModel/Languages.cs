using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/languages/{id}")]
public class Languages : PagedRequest, IGet, IReturn<PagedDictionaryResponse>
{
    public string Id { get; set; }
}

//public class LanguagesResponse : PagedDictionaryResponse { }