using calamansi.ServiceModel.ProxyModels;

namespace calamansi.ServiceModel;

public class ItemResponse
{
    public string Name { get; set; }
    public List<Country> Countries { get; set; }
}