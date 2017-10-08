using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AG.Common.Enums;

namespace AG.Common.Models.Logger
{
   public class FileLogger : ILogger
   {
        private string LogFileName;
        private const string singleDivider = "------------------------------------------------------------";
        private const string doubleDivider = "============================================================";
        public FileLogger(string logFileName = null)
        {
            //use default from settings if filename not specified
            //TODO get from settings            
            LogFileName = string.IsNullOrEmpty(logFileName) ? $"{Directory.GetCurrentDirectory()}\\log.txt" : LogFileName;

            try
            {
                using (TextWriter tw = new StreamWriter(LogFileName, true))
                {
                    tw.WriteLine(doubleDivider);
                    tw.WriteLine($"Logging Initialised @ {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    tw.WriteLine(doubleDivider);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogInformation(string message)
        {
            Log(SeverityEnum.Information, message, null);
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
            try
            {
                using (TextWriter tw = new StreamWriter(LogFileName,true))
                {
                    tw.WriteLine(doubleDivider);
                    tw.WriteLine($"Log Entry: @ {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    tw.WriteLine(singleDivider);
                    tw.WriteLine($"{severity.ToString()}:{message}");
                    if (exception != null)
                    {
                        tw.WriteLine($"Stack Trace : {exception.StackTrace}");
                    }
                    tw.WriteLine(doubleDivider);
                }
            }
            catch (Exception ex)
            {
                //Where to log?
            }

        }





    }
}
