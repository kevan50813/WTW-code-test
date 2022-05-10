using DataTriangle;

namespace textparser
{
    class Program
    {
        public static void Main(string[] args)
        {
            FileOperation fileOperation = new FileOperation();
            Parser parser = new Parser();
            Output o = new Output(new DataCalculator());
            Console.WriteLine("Enter a File to read: ");
            string filename = Console.ReadLine();
            if (fileOperation.doseFileExsit(filename))
            {
                Console.WriteLine("Processing: " + filename);
                DataTriangle dt = new DataTriangle(fileOperation,parser,o);

                if (dt.convertDataTriangle(filename))
                {
                    Console.WriteLine("Coversion Successfull");
                }
                else
                {
                    Console.WriteLine("Coversion Failed , The input data contins invlid values");
                }

            }
            else
            {
                Console.WriteLine("Could not find file to read");
                Environment.Exit(0);
            }
        }
    }
}