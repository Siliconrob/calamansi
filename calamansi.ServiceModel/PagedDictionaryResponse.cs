using calamansi.ServiceModel.ProxyModels;

namespace calamansi.ServiceModel;

public class PagedDictionaryResponse
{
    public required Dictionary<string, List<Country>>.ValueCollection Items { get; set; }
    public required int ItemCount { get; set; }
    public required int Page { get; set; }
    public required int PageCount { get; set; }
    public required int Total { get; set; }
}
