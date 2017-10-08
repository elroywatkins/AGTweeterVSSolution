using System;
using System.Collections.Generic;
using AG.Common;
using AG.Common.Models.Logger;
using AG.BLL;

namespace AG.TweeterConsoleApp
{
    public class Tweeter
    {
        private TweeterService tweeterService;
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
                logger = new FileLogger();
            }
            catch (Exception ex)
            {                
                Console.WriteLine("An error occurred initializing the Logger");
                Console.WriteLine($"Exception: {ex.Message}");
                return result;
            }

            //validation IOC
            //try
            //{
            //   IValidator validator = new ConsoleValidator();
            //}
            //catch (Exception ex)
            //{

            //}

            //Data access IOC
            //IDataAccess fileDataAccess = new FileDataAccess();

            //service instance
            tweeterService = new TweeterService(logger);
            tweetMessages = tweeterService.GetTweetsByAllUsers();
            return result;
        }

        // Method to print results to screen
        private void PrintDisplay(IList<TweetStructure> tweetMessages)
        {
            throw new NotImplementedException();
        }
    }
}
