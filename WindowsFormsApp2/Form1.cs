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
            string[] files = Directory.GetFiles(@"C:\Users\Public\Documents\Chroma 11210 TCP Listener\", "*.json");
            List<string> validCommands = new List<string>();
            
            // Loop through the files and add the file name without the extension to the list
            foreach (string file in files)
            {
                
                string a = Path.GetFileNameWithoutExtension(file);
                a = a.Replace("_", ":");
                validCommands.Add(a);
            }
            
            
            // Check if the command is valid
            string matchedCommand = validCommands.FirstOrDefault(c => command.StartsWith(c));
            
            if (matchedCommand == null)
            {
                // Command not recognized, return error message
                responseMessage2 = "Invalid command.";
            }
            
            // Check if the command is valid
            if (validCommands.Contains(matchedCommand))
            {
                                    
                // string a = matchedCommand;
                // a += ".json";
                // string path = @"C:\Users\Public\Documents\Chroma 11210 TCP Listener\" + a;
                // var json = File.ReadAllText(path);
                //
                // JObject root = JObject.Parse(json);

                // JSON folder path
                string filePath = @"C:\Users\31629\source\repos\Chroma 11210 TCP Listener\Chroma 11210 TCP Listener\JSON\";

                // Create a new file name
                string newFileName = matchedCommand;
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

                    
                    // Check if the command ends with a question mark
                    if (matchedCommand.EndsWith("?"))
                    {
                        // Handle the command with a question mark
                    
                    
                    }
                    // Check if the command ends with "MAX"
                    else if (matchedCommand.EndsWith("MAX"))
                    {
                        double resolutionParameter = (double)o["LCTestCONFigureTIMECHG"]["maxParameter"];
                        JToken setCommandToken = o["LCTestCONFigureTIMECHG"]?["ReturnValue"];
                        if (setCommandToken != null && setCommandToken.Type == JTokenType.Float)
                        {
                            setCommandToken.Replace(resolutionParameter);
                        }
                        File.WriteAllText(newFilePath, o.ToString());

                        // Handle the command with "MAX"
                    }
                    // Check if the command ends with "MIN"
                    else if (matchedCommand.EndsWith("MIN"))
                    {
                        double resolutionParameter = (double)o["LCTestCONFigureTIMECHG"]["minParameter"];
                        JToken setCommandToken = o["LCTestCONFigureTIMECHG"]?["ReturnValue"];
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
                        //
                        
                        // Overwrite the value of the "SetCommand" node
                        JToken setCommandToken = o["LCTestCONFigureTIMECHG"]?["ReturnValue"];

                        if (setCommandToken != null && setCommandToken.Type == JTokenType.Float)
                        {
                            setCommandToken.Replace(40.0);
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