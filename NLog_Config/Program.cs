using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog_Config
{
    internal class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            logger.Trace("我是追蹤:Trace");
            logger.Debug("我是偵錯:Debug");
            logger.Info("我是資訊:Info");
            logger.Warn("我是警告:Warn");
            logger.Error("我是錯誤:error");
            logger.Fatal("我是致命錯誤:Fatal");
        }
    }
}