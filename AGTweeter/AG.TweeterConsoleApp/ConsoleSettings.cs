using System.IO;

namespace AG.TweeterConsoleApp
{
    public class ConsoleSettings
    {
        public static string AppBasePath { get;}
        public static string UsersFilePath { get; }
        public static string TweetsFilePath { get;}        
        public static string LogFilePath { get; }
       
        public static readonly ConsoleSettings instance = new ConsoleSettings();
        
        ConsoleSettings(){ }
        static ConsoleSettings()
        {
            //TODO load from setting.json file
            AppBasePath = Directory.GetCurrentDirectory();
            LogFilePath = $"{AppBasePath}\\log.txt";
            UsersFilePath = $"{AppBasePath}\\inputfiles\\User.txt";
            TweetsFilePath = $"{AppBasePath}\\inputfiles\\Tweet.txt";
           
        }
    }
}