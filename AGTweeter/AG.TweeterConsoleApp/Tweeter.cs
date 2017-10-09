using System;
using System.Collections.Generic;
using AG.Common;
using AG.Common.Models.Logger;
using AG.TweeterBLL;
using AG.TweeterDAL;

namespace AG.TweeterConsoleApp
{
    public class Tweeter
    {
        private TweeterBLL.TweeterService tweeterService;
        private IList<TweetStructure> tweetMessages;
        
        public void Run()
        {
            Console.WriteLine("Running Tweeter Console Application");
            Console.WriteLine("===================================");

            //Initialise service
            if (InitTweeterServiceForConsole())
            {
                //Console specific display
                //Only print if Service is successfully initialized
                //PrintDisplay(tweetMessages);                
            }

            Console.WriteLine("===================================");
            Console.WriteLine("End of Tweeter Console Application, press any key to continue");
            Console.ReadKey();
        }

        private bool InitTweeterServiceForConsole()
        {
            bool result = false; 
            ILogger logger;
            //logger IOC
            try
            {
                //LogFileName = string.IsNullOrEmpty(logFileName) ? $"{Directory.GetCurrentDirectory()}\\log.txt" : LogFileName;
                logger = new FileLogger(ConsoleSettings.LogFilePath);                
            }
            catch (Exception ex)
            {                
                Console.WriteLine("An error occurred initializing the Logger");
                Console.WriteLine($"Exception: {ex.Message}");
                return result;
            }

            //Data access IOC            
            IDataSource userDataSource = new FileDataSource(ConsoleSettings.UsersFilePath,logger);
            IDataSource tweetsDataSource = new FileDataSource(ConsoleSettings.TweetsFilePath, logger);

            //service instance
            try
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Processing Tweets");
                Console.WriteLine("-----------------");
                tweeterService = new TweeterBLL.TweeterService(logger, userDataSource, tweetsDataSource);
                tweetMessages = tweeterService.GetTweetsByAllUsers();
                PrintDisplay(tweetMessages);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred initializing the tweeter service");
                Console.WriteLine($"Exception: {ex.Message}");
                return result;
            }

            return result;
        }

        // Method to print results to screen
        private void PrintDisplay(IList<TweetStructure> tweetMessages)
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Printing Tweets");
            Console.WriteLine("---------------");
        }
    }
}
