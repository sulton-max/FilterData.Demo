using System.Collections.ObjectModel;

namespace FilterData.Demo.App;

public class QueryResult<TSource>
{
    public ICollection<TSource> Data { get; set; }

    public ReadOnlyCollection<FilterData<Industry>> FilterData { get; set; }
}