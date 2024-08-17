using System.Runtime.Serialization;
using ServiceStack;

namespace calamansi.ServiceModel;

public class PagedRequest : SortedRequest
{
    [ApiMember(Name = "limit",
        Description = "Items per page",
        ParameterType = "query",
        //DataType = "object",
        IsRequired = false
    )]    
    public int Limit { get; set; } = 10;
    [ApiMember(Name = "page",
        Description = "Page number: default is (10)",
        ParameterType = "query",
        DataType = "integer",
        IsRequired = false
    )]
    public int Page { get; set; } = 1;
}

public class SortedRequest
{
    [ApiMember(Name = "find",
        Description = "Search by text in results: default is (empty)",
        ParameterType = "query",
        DataType = "string",
        IsRequired = false
    )]
    public string Find { get; set; } = "";    
    [ApiMember(Name = "sort_by",
        Description = "Sort results by property values: default is (empty)",
        ParameterType = "query",
        DataType = "string",
        IsRequired = false
    )]
    [DataMember(Name = "sort_by")]
    public string Sort_By { get; set; } = "";
    [ApiMember(Name = "sort_desc",
        Description = "Sort results descending: default is (false)",
        ParameterType = "query",
        DataType = "boolean",
        IsRequired = false
    )]
    [DataMember(Name = "sort_desc")]
    public bool Sort_Desc { get; set; }
}