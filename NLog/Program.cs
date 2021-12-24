using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    internal class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            
            var logfile = new NLog.Targets.FileTarget() { FileName = "NLog123.log", Name = "logfile" };
            var logconsole = new NLog.Targets.ConsoleTarget() { Name = "logconsole" };
            
            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Info, logconsole));
            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logfile));
            
            NLog.LogManager.Configuration = config;

            logger.Error("This is an error message");
            logger.Error("This is an error message");
            logger.Error("This is an error message");


        }
    }
}