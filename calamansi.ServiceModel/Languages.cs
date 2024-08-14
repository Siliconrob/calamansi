using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/languages/{id}")]
public class Languages : IGet, IReturn<LanguagesResponse>
{
    public string Id { get; set; }
}

public class LanguagesResponse
{
    public required string Result { get; set; }
}