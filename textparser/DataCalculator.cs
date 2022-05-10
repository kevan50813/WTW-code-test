namespace textparser;

public class DataCalculator
{
    public List<double> Calculate(Product product)
    {
        double[,] data = new double[product.DevYears, product.DevYears];
        List<double> dataTrianlge = new List<double>();
        if (!product.ProductName.Any())
        {
            return new List<double>();
        }

        for (int i = 0; i < product.DevYears; i++)
        {
            List<IncrementalValues> incVals = product.IncrementalValues.Where(x => x.originYear == product.OriginYear + i).ToList();
            for (int j = 0; j < product.DevYears - i; j++)
            {
                double incVal = incVals.Where(y => y.developmentYear == y.originYear + j).Select(x => x.incremntalValue)
                    .FirstOrDefault();
                data[i, j] = incVal + data[i, (j - 1) < 0 ? j : j - 1];
                dataTrianlge.Add(data[i,j]);
            }
        }

        return dataTrianlge;
    }
}