namespace FilterData.Demo.App;

public class ProductFilter : FilterPagination
{
    public string? SearchKeyword { get; set; }
    
    public Industry? Industry { get; set; }
}

public class FilterPagination
{
    public int PageToken { get; set; }
    
    public int PageSize { get; set; }
}