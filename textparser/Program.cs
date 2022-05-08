using DataTriangle;

namespace textparser
{
    class mainclass
    {
        public static void Main(string[] args)
        {
            FileOperation fileOperation = new FileOperation();
            Parser parser = new Parser();
            Output o = new Output();
            string fileName = Console.ReadLine();
            if (fileOperation.doseFileExsit(fileName))
            {
                Console.WriteLine("Processing: " + fileName);
                DataTriangle dt = new DataTriangle(fileOperation,parser,o);
                

            }
            else
            {
                Console.WriteLine("Could not find file to read");
                Environment.Exit(0);
            }
        }
    }
}