namespace textparser;

public class Output
{
    private DataTriangle dt;
    public List<string> CreateOutputContent(List<IncrementalValues> iv)
    {
        //calculate the origin year and devleopmt years
        IEnumerable<int> originYears = iv.Select(x => x.originYear).Distinct().OrderBy(x => x);
        int originYear = originYears.First();
        int developmentYears = originYears.Last() - originYear + 1;

        List<string> outputList = new List<string>();
        outputList.Add(string.Format("{0},{1}",originYear,developmentYears));

        var products = getProducts(iv, originYear, developmentYears);
        foreach (Product product in products)
        {
            outputList.Add(string.Format("{0},{1}"),product.ProductName,string.Join(",",DataTriangle.Calculate(product)));
        }

    }

    private IEnumerable<string> getProducts(List<IncrementalValues> iv, int originYear, int developmentYears)
    {
        IEnumerable<string> productNames = iv.Select(x => x.pName.ToLowerInvariant()).Distinct();
        return productNames.Select(productNames=>new Product()
        {
            PName=pName,
            OriginYear = originYear,
            DevYears = developmentYears,
            incremetalValues=iv.Where(x=>string.Compare(x.pName,PName,StringComparison.OrdinalIgnoreCase)==0)
        });
    }
}