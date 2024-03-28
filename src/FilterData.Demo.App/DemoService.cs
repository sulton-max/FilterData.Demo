using System.Collections.ObjectModel;
using System.Reflection;

namespace FilterData.Demo.App;

public static class DemoService
{
    public static IQueryable<Product> Products;

    static DemoService()
    {
        var random = new Random();
        Products = Enumerable.Range(0, 30)
            .Select(
                _ => new Product
                {
                    Industry = (Industry)random.Next(0, 4)
                }
            )
            .ToList()
            .AsQueryable();
    }

    public static ValueTask<QueryResult<Product>> GetAsync(ProductFilter filter)
    {
        var productsQuery = Products;

        if (filter.Industry.HasValue)
            productsQuery = productsQuery.Where(p => p.Industry == filter.Industry);

        if (!string.IsNullOrWhiteSpace(filter.SearchKeyword))
            productsQuery = productsQuery.Where(p => p.Name.Contains(filter.SearchKeyword));

        var matchedProducts = productsQuery.Skip((filter.PageToken - 1) * filter.PageSize).Take(filter.PageSize).ToList();

        // Assuming FilterData is correctly defined and we want to aggregate by the Industry property.
        var filterData = matchedProducts
            .GroupBy(product => product.Industry)
            .Select(group => new FilterData<Industry>
            {
                Key = nameof(Industry),
                Value = group.Key,
                Count = (ulong)group.Count()
            })
            .ToList();

        // Converting List<FilterData<Industry>> to ReadOnlyCollection<FilterData<Industry>>
        var readOnlyFilterData = new ReadOnlyCollection<FilterData<Industry>>(filterData);

        return new ValueTask<QueryResult<Product>>(
            new QueryResult<Product>
            {
                Data = matchedProducts,
                FilterData = readOnlyFilterData
            }
        );
    }
}