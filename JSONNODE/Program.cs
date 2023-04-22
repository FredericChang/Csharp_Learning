using System.IO;
using Newtonsoft.Json.Linq;

namespace JSONNODE
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            string json = @"{
              CPU: 'Intel',
              Temperature: 30.0,
              Drives: [
                'DVD read/writer',
                '500 gigabyte hard drive'
              ]
            }";

            string filePath = @"C:\Users\31629\source\repos\Chroma 11210 TCP Listener\Chroma 11210 TCP Listener\JSON\";

            string newFileName = "LCTest:CONFigure:TIME:CHG";
            newFileName = newFileName.Replace(":", "");
            newFileName+= ".json";
            
            string directoryPath = Path.GetDirectoryName(filePath);
            string newFilePath = Path.Combine(filePath, newFileName);
            
            // Load the JSON file into a string
            string json2 = File.ReadAllText(newFilePath);
            // Create a FileInfo object to represent the file
            FileInfo fileInfo = new FileInfo(newFilePath);

            // Check if the file exists
            if (fileInfo.Exists)
            {
                JObject o = JObject.Parse(json2);
            
                // Modify the value of the "Temperature" node
                JToken setCommandToken = o["LCTestCONFigureTIMECHG"]?["MaxParameter"];

                if (setCommandToken != null && setCommandToken.Type == JTokenType.Float)
                {
                    setCommandToken.Replace(40.0);
                }
            
                File.WriteAllText(newFilePath, o.ToString());
            }
            else
            {
                // File does not exist, do something else
            }
            
            


            // // Load the JSON file into a string
            // string json = File.ReadAllText("path/to/json/file.json");
            //
            // // Parse the JSON string into a JObject
            // JObject root = JObject.Parse(json);
            //
            // // Modify the value of the "Temperature" node
            // JToken temperatureNode = root["Temperature"];
            // if (temperatureNode != null && temperatureNode.Type == JTokenType.Float)
            // {
            //     temperatureNode.Replace(30.0);
            // }
            //
            // // Write the updated JSON back to the file
            // File.WriteAllText("path/to/json/file.json", root.ToString());
            //
        }
    }
}