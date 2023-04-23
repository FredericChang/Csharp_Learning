using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = textBox1.Text;
            string responseMessage2 = string.Empty;
            // string command = string.Empty;
            
            // Define a list of valid commands that the server can handle
            
            //get local folder called JSON to read the json files name and store in a list
            string[] files = Directory.GetFiles(@"C:\Users\31629\source\repos\Chroma 11210 TCP Listener\Chroma 11210 TCP Listener\JSON\", "*.json");
            List<string> validCommands = new List<string>();
            
            // Loop through the files and add the file name without the extension to the list
            foreach (string file in files)
            {
                string a = Path.GetFileNameWithoutExtension(file);
                a = a.Replace("_", ":");
                validCommands.Add(a);
            }
            string[] subs = command.Split(' ');
            
            
            // Check if the command is valid
            string matchedCommand = validCommands.FirstOrDefault(c => command.StartsWith(c));
            
            if (matchedCommand == null)
            {
                // Command not recognized, return error message
                responseMessage2 = "Invalid command.";
            }
            
            // Check if the command is valid
            else if (validCommands.Contains(matchedCommand))
            {
                
                // JSON folder path
                string filePath = @"C:\Users\31629\source\repos\Chroma 11210 TCP Listener\Chroma 11210 TCP Listener\JSON\";

                // Create a new file name
                string newFileName = matchedCommand;
                newFileName = newFileName.Replace(":", "_");
                newFileName+= ".json";
                
                string itemName = matchedCommand.Replace(":", "");
            
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
                    
                    // Check if the command ends with a question mark
                    if (command.EndsWith("?"))
                    {
                        // Handle the command with a question mark
                        JToken setCommandToken = o[itemName]?["ReturnData"];
                        Console.WriteLine(setCommandToken);
                        textBox2.Text = setCommandToken.ToString();
                    
                    }
                    // Check if the command ends with "MAX"
                    else if (command.EndsWith("MAX") || command.EndsWith("ON"))
                    {
                        double resolutionParameter = (double)o[itemName]["MaxParameter"];
                        JToken setCommandToken = o[itemName]?["ReturnData"];
                        if (setCommandToken != null && setCommandToken.Type == JTokenType.Float)
                        {
                            setCommandToken.Replace(resolutionParameter);
                        }
                        File.WriteAllText(newFilePath, o.ToString());

                        // Handle the command with "MAX"
                    }
                    // Check if the command ends with "MIN"
                    else if (command.EndsWith("MIN") || command.EndsWith("OFF"))
                    {
                        double resolutionParameter = (double)o[itemName]["MinParameter"];
                        JToken setCommandToken = o[itemName]?["ReturnData"];
                        if (setCommandToken != null && setCommandToken.Type == JTokenType.Float)
                        {
                            setCommandToken.Replace(resolutionParameter);
                        }
                        File.WriteAllText(newFilePath, o.ToString());

                    }
                    else
                    {
                        // Handle the command without any special ending
                        // string setCommand = (string)root["LCTest:CONFigure:TIME:CHG"]["SetCommand"];
                        // double resolutionParameter = (double)root["LCTest:CONFigure:TIME:CHG"]["ResolutionParameter"];
                        // Overwrite the value of the "SetCommand" node
                        JToken setCommandToken = o[itemName]?["ReturnData"];
                        
                        if (setCommandToken != null && setCommandToken.Type == JTokenType.Float)
                        {
                            double value = double.Parse(subs[1]);
                            setCommandToken.Replace(value);
                        }
            
                        File.WriteAllText(newFilePath, o.ToString());
                    
                    }

                }
                else
                {
                    // File does not exist, do something else
                }
        
            }
            
            else
            {
                // Command not recognized, return error message
                responseMessage2 = "Invalid command.";
            }
        }
    }
}