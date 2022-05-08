using DataTriangle;

namespace textparser;

public class DataTriangle
{
    public Output o;
    public FileOperation fo;
    public Parser p;
    
    public DataTriangle(FileOperation fo, Parser p, Output o)
    {
        this.fo = fo;
        this.p = p;
        this.o = o;
    }

    public bool convertDataTriangle(string filename)
    {
        string[] input = fo.readFile(filename);
        List<IncrementalValues> iv = p.ParseInput(input);
        List<string> output = o.CreateOutputContent(iv);
        //TODO
        try
        {
            fo.writeToFile();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured");
            return false;
        }
        
        if(p.invalidRows.Any())
        {
            return false;
        }

        return true;
    }


}
