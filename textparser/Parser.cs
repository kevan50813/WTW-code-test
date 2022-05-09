using System.Collections.Specialized;
using System.IO.Compression;

namespace textparser;
using System.Linq;
public class Parser
{
    private const int minimumYear = 1800;
    private int headingIndex = 0;
    public Parser()
    {
        invalidRows = new List<string>();
    }

    public List<string> invalidRows
    {
        get; 
        set;
    }

    public List<IncrementalValues> ParseInput(string[] input)
    {
        throw new NotImplementedException();
    }

    private IncrementalValues createIncrementalValues(string row, int rowVlaues, Columns colIndex)
    {
        throw new NotImplementedException();
    }

    private Columns createColumnIndex(List<string> headings)
    {
        return new Columns
        {
            ProductIndex = headings.IndexOf("product"),
            OriginYearIndex = headings.IndexOf("origin year"),
            DevYearIndex = headings.IndexOf("development year"),
            IncValIndex = headings.IndexOf("incremental value"),
        };
    }

    private static List<string> splitRow(string row)
    {
        return row.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
    }

    private bool validateParamiters(string name,int originYear,int devYear)
    {
        throw new NotImplementedException();
    }
}