using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApplication3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json =
                File.ReadAllText(
                    @"C:\Users\31629\source\repos\FredericChang\Chroma-11210-winform\Chroma 11210 winform\Command\Utility\TotalA.json");

            Dictionary<string, Command> commands = JsonConvert.DeserializeObject<Dictionary<string, Command>>(json);

            foreach (KeyValuePair<string, Command> kvp in commands)
            {
                string fileName = $"{kvp.Key}.json";
                string jsonContent = JsonConvert.SerializeObject(kvp.Value, Formatting.Indented);
                string fileName2 = @"C:\Users\31629\source\repos\FredericChang\Chroma-11210-winform\Chroma 11210 winform\Command\Utility\" + fileName;
                File.WriteAllText(fileName2, jsonContent);
            }
        }
    }

    public class Command
    {
        public string SetCommand { get; set; }
        public string QueryCommand { get; set; }
        public double? ResolutionParameter { get; set; }
        public double? MaxParameter { get; set; }
        public double? MinParameter { get; set; }
        public Dictionary<string, int> Parameter { get; set; }
        public int? ReturnData { get; set; }
    }
}