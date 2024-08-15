using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/languages/{id}")]
public class Languages : PagedRequest, IGet, IReturn<LanguagesResponse>
{
    public string Id { get; set; }
}

public class LanguagesResponse
{
    public List<LanguageItem> Items { get; set; }
}

public class LanguageItem
{
}