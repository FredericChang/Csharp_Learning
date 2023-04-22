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

namespace JOBJECT_TEST_FORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<string> validCommands = new List<string>()
            {
                "LCTest:ConFigure:TIme:CHG",
            };
            var command = "LCTest:ConFigure:TIme:CHG MAX";
            

            string matchedCommand = validCommands.FirstOrDefault(c => command.StartsWith(c));

            
            
            
            

            
        }
        
        
        
    }
}