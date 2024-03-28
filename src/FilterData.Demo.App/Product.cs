using FilterData.Demo.App;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "Test";
 
    [FilteredProperty]
    public Industry Industry { get; set; }
}