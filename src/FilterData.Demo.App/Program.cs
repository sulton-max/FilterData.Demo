using FilterData.Demo.App;

var filter = new ProductFilter
{
    PageToken = 1,
    PageSize = 10,
    SearchKeyword = "Test"
};

var result = await DemoService.GetAsync(filter);

Console.ReadLine();