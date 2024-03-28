namespace FilterData.Demo.App;

public class FilterData<TValue> : FilterData
{
    public TValue Value { get; set; }
}

public class FilterData
{
    public string Key { get; set; }
    
    public ulong Count { get; set; }
}