using DataTriangle;

namespace textparser;

public class DataTriangle
{
    private string InvalidValues = "INVALID VALUE";
    private Output output;
    private FileOperation fileoperator;
    private Parser parser;

    public DataTriangle(FileOperation fo, Parser p, Output o)
    {
        output = o;
        parser = p;
        fileoperator = fo;
    }

    public bool convertDataTriangle(string filename)
    {
        IList<string> input = fileoperator.readFile(filename);
        List<IncrementalValues> parsedValues = parser.ParseInput(input);
        IList<string> outputContent = output.CreateOutputContent(parsedValues);

        try
        {
            fileoperator.writeToFile(filename,outputContent);
            if (parser.invalidRows.Any())
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return true;

    }
    
}