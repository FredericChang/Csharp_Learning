using System;
using System.IO;

namespace IO_File
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string filePath = @"C:\Users\31629\source\repos\Chroma 11210 TCP Listener\Chroma 11210 TCP Listener\JSON\";

            string newFileName = "LCTest:CONFigure:TIME:CHG";
            newFileName = newFileName.Replace(":", "");
            newFileName+= ".json";
            
            string directoryPath = Path.GetDirectoryName(filePath);
            string newFilePath = Path.Combine(filePath, newFileName);
            
            
            // Create a FileInfo object to represent the file
            FileInfo fileInfo = new FileInfo(newFilePath);

            // Check if the file exists
            if (fileInfo.Exists)
            {
                // File exists, do something
                Console.WriteLine("File exists");
            }
            else
            {
                // File does not exist, do something else
                Console.WriteLine("File does not exist");
            }

            
        }
    }
}