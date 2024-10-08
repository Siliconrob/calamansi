﻿using calamansi.ServiceModel.ProxyModels;
using ServiceStack;

namespace calamansi.ServiceModel;

[Route("/api/regions/{id}")]
public class Regions : PagedRequest, IGet, IReturn<RegionsResponse>
{
    [ApiMember(Name = "id",
        Description = "Search by region id: default is (empty), in OpenAPI interactive fill with `\"\"`",
        ParameterType = "path",
        DataType = "string"
    )]
    public string Id { get; set; } = "";
}

public class RegionsResponse
{
    public required List<RegionResponseItem> Items { get; set; } 
    public required int ItemCount { get; set; }
    public required int Page { get; set; }
    public required int PageCount { get; set; }
    public required int Total { get; set; }
}

public class RegionResponseItem
{
    public required string Region { get; set; }
    public required List<Country> Items { get; set; }
}