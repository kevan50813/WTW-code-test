namespace textparser;

//Class that reperesnts the prodccus thats in the text file
public class Product
{
    public int OriginYear
    {
        get;
        set;
    }

    public int DevYears
    {
        get;
        set;
    }

    public string ProductName
    {
        get;
        set;
    }

    public IEnumerable<IncrementalValues> IncrementalValues
    {
        get;
        set;
    }
}