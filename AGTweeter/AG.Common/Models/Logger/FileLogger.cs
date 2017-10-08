using System;
using System.Collections.Generic;
using System.Text;
using AG.Common.Enums;

namespace AG.Common.Models.Logger
{
   public class FileLogger : ILogger
    {        

        public void LogError(string Message, Exception exception = null)
        {
            throw new NotImplementedException();
        }

        public void LogInformation(string Message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string Message, Exception exception = null)
        {
            throw new NotImplementedException();
        }

        private void Log(SeverityEnum severity, string Message, Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }
}
