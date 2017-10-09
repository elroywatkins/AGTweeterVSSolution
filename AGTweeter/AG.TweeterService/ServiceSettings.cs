using System.IO;

namespace AG.TweeterService
{
    public class ServiceSettings
    {
        public static string FileDelimiterFollows { get; }
        public static string FileDelimiterTweet { get; }
        public static readonly ServiceSettings instance = new ServiceSettings();

        ServiceSettings() { }
        static ServiceSettings()
        {
            //TODO load from setting.json file
            FileDelimiterFollows = "follows";
            FileDelimiterTweet = ">";
        }
    }
}


