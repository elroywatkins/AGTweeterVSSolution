using System;
using System.IO;
using AG.Common.Enums;

namespace AG.Common
{
    public interface ILogger
    {
        void LogInformation(string Message);
        void LogWarning(string Message, Exception exception = null);
        void LogError(string Message, Exception exception = null);
        //void Log(SeverityEnum severity, string Message,Exception exception = null);
    }
}