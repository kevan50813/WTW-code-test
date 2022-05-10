namespace textparser;

public class Output
{
    private DataCalculator dc;

    public Output(DataCalculator dc)
    {
        this.dc = dc;
    }
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
            outputList.Add(string.Format("{0},{1}"),product.ProductName,string.Join(",",dc.Calculate(product)));
        }

        return outputList;

    }

    private IEnumerable<Product> getProducts(List<IncrementalValues> iv, int originYear, int developmentYears)
    {
        IEnumerable<string> productNames = iv.Select(x => x.pName.ToLowerInvariant()).Distinct();
        return productNames.Select(pName=>new Product()
        {
            ProductName= pName,
            OriginYear = originYear,
            DevYears = developmentYears,
            IncrementalValues = iv.Where(x=>string.Compare(x.pName,pName,StringComparison.OrdinalIgnoreCase)==0)
        });
    }
}