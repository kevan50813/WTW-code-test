namespace DataTriangle;
using System;
using System.IO;
using System.Collections.Generic;
public class FileOperation
{
    public bool doseFileExsit(string? filename)
    {
        return File.Exists(filename); 
    }
    public IList<string> readFile(string? filename)
    {
        try
        {
            return File.ReadAllLines(filename);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not read file into list: ",e);
            throw;
        }
    }

    public bool writeToFile(string filename,IEnumerable<string> contents)
    {
        try
        {
            if (string.IsNullOrEmpty(filename))
            {
                return false;
            }
            File.WriteAllLines(filename, contents);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not write to file ", filename);
            Console.WriteLine(e);
            throw;
        }

        return true;
    }
}