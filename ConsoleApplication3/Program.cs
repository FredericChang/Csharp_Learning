using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApplication3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("commands.json");

            Dictionary<string, Command> commands = JsonConvert.DeserializeObject<Dictionary<string, Command>>(json);

            foreach (KeyValuePair<string, Command> kvp in commands)
            {
                string fileName = $"{kvp.Key}.json";
                string jsonContent = JsonConvert.SerializeObject(kvp.Value, Formatting.Indented);
                File.WriteAllText(fileName, jsonContent);
            }
        }
    }

    public class Command
    {
        public string SetCommand { get; set; }
        public string QueryCommand { get; set; }
        public int? ResolutionParameter { get; set; }
        public int? MaxParameter { get; set; }
        public int? MinParameter { get; set; }
        public Dictionary<string, int> Parameter { get; set; }
        public int? ReturnData { get; set; }
    }
}