using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using AG.Common.Enums;

namespace AG.Common.Models.Logger
{
   public class ConsoleLogger : ILogger
    {        

        public void LogInformation(string message)
        {
            Log(SeverityEnum.Information, message,null);
        }

        public void LogWarning(string message, Exception exception = null)
        {
            Log(SeverityEnum.Warning, message, exception);
        }

        public void LogError(string message, Exception exception = null)
        {
            Log(SeverityEnum.Error, message, exception);
        }

        private void Log(SeverityEnum severity, string message, Exception exception = null)
        {
            Console.WriteLine($"{severity.ToString()}:{message}");
            if (exception != null)
            {
                Console.WriteLine($"Stack Trace : {exception.StackTrace}");
            }
        }
    }
}
