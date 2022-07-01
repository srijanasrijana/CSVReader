// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.IO;
using System.Collections.Generic;

public class CSVReader 
{   
    public static void Main(string[] args)
    {
        //Check argument length 
        if(args.Length != 3)
        {
            Console.WriteLine("Invalid Number of Arguments!!!");
            System.Environment.Exit(0);

        }
        //Variable declare
        string path= args[0];
        //convert string to int by parse
        int columnNumber = Int32.Parse(args[1]); 
        string searchKey = args[2];
        //Call Read Function with pass argument
        Read(path, columnNumber, searchKey);
    }

    public static void Read(string path,int columnNumber, string searchKey)
    {
        //Check in case of file path not available
        if(!File.Exists(path))
        {
            Console.WriteLine("File does not exist!!!");
            System.Environment.Exit(0);
        }
        //To read file path 
        using (var reader = new StreamReader(@" " + path + " "))
        {

            bool found = false;
            //To read  csv file record
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                //Split record using split function
                var values = line.Split(',');
                //Check Index
                int len = values.Length;
                //Check csv file column number
                if(columnNumber > len-1)
                {
                    Console.WriteLine("Invalid Column Number!!!");
                    System.Environment.Exit(0);
                }
                //search key with column number
                if (values[columnNumber].Equals(searchKey))
                {
                    found = true;
                    Console.WriteLine(line);
                }
            }
            //Check in case of record not available
            if (!found)
            {
                Console.WriteLine("Records Not Found!!!");
            }
        }
    }
}
