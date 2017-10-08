using AG.Common;
using System;
using System.Collections.Generic;

namespace AG.BLL
{
    public class TweeterService
    {
        private ILogger Logger;
        public TweeterService(ILogger logger)
        {
            Logger = logger;
        }

        public IList<TweetStructure> GetTweetsByAllUsers()
        {
            Logger.LogError("No info");
            return null;
            
        }

    }
}
