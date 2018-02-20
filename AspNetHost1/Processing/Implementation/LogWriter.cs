using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AspNetHost1.Processing.Implementation
{
    public class LogWriter : ILogWriter
    {
        public void LogMessage(string message)
        {
            File.AppendAllText(@"D:\MP\WebhookLog.txt",
                   $"{DateTime.Now} {message} {Environment.NewLine}");
        }
    }
}