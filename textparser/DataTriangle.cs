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

    public bool convertDataTriangle(string? filename)
    {
        IList<string> input = fileoperator.readFile(filename);
        List<IncrementalValues> parsedValues = parser.ParseInput(input);
        IList<string> outputContent = output.CreateOutputContent(parsedValues);

        try
        {
            string path = filename.Substring(0, filename.LastIndexOf('/'));
            string outfile = path + "/Output.txt";
            fileoperator.writeToFile(outfile,outputContent);
            if (parser.invalidRows.Any())
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not Covert triangle");
            return false;
        }

        return true;

    }
    
}