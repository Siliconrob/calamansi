using calamansi.ServiceModel.ProxyModels;
using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/languages/{id}")]
public class Languages : PagedRequest, IGet, IReturn<LanguagesResponse>
{
    public string Id { get; set; }
}

public class LanguagesResponse
{
    public required List<LanguageResponseItem> Items { get; set; } 
    public required int ItemCount { get; set; }
    public required int Page { get; set; }
    public required int PageCount { get; set; }
    public required int Total { get; set; }
}

public class LanguageResponseItem
{
    public required string Language { get; set; }
    public required List<Country> Items { get; set; }
}