namespace DataTriangle;
using System;
using System.IO;
using System.Collections.Generic;
public class FileOperation
{
    public bool doseFileExsit(string fileName)
    {
        return File.Exists(fileName); 
    }

    public string[] readFile(string fileName)
    {
        try
        {
            return File.ReadAllLines(fileName);
        }
        catch (Exception e)
        {
            Console.WriteLine("Could not read file into list");
            throw;
        }
    }
}