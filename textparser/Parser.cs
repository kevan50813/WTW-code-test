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

    public List<IncrementalValues> ParseInput(IList<string> input)
    {
        var headings = splitRow(input.ElementAt(headingIndex)).Select(x => x.ToLowerInvariant()).ToList();
        List<IncrementalValues> parsedValues = new List<IncrementalValues>();
        Columns columnIndexes = createColumnIndex(headings);
        if (columnIndexes.ProductIndex == -1 || columnIndexes.OriginYearIndex == -1 ||
            columnIndexes.DevYearIndex == -1 || columnIndexes.IncValIndex == -1)
        {
            return new List<IncrementalValues>();
        }

        foreach (string i in input.Skip(1))
        {
            IncrementalValues value = createIncrementalValues(i, headings.Count, columnIndexes);
            parsedValues.Add(value);
        }

        return parsedValues;
    }

    private IncrementalValues createIncrementalValues(string row, int numRowValues, Columns colIndex)
    {
        List<string> rowValues = splitRow(row);
        string name = rowValues[colIndex.ProductIndex];
        int originYear = 0;
        int devYear = 0;
        double incremntalValue = 0;
        if (rowValues.Count != numRowValues)
        {
            invalidRows.Add(row);
        }

        else if (!int.TryParse(rowValues[colIndex.OriginYearIndex], out originYear))
        {
            invalidRows.Add(row);
            return null;
        }
        else if (!int.TryParse(rowValues[colIndex.DevYearIndex], out devYear))
        {
            invalidRows.Add(row);
            return null;
        }
        else if (!double.TryParse(rowValues[colIndex.IncValIndex], out incremntalValue))
        {
            invalidRows.Add(row);
            return null;
        }

        else if (!validateParamiters(name, originYear, devYear))
        {
            invalidRows.Add(row);
            return null;
        }
        var incValues = new IncrementalValues
        {
            pName = name,
            originYear= originYear,
            developmentYear= devYear,
            incremntalValue = incremntalValue
        };
        return incValues;
        
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
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        if (originYear <= minimumYear || originYear > DateTime.Now.Year)
        {
            return false;
        }

        return devYear <= DateTime.Now.Year && devYear >= originYear;
    }
}