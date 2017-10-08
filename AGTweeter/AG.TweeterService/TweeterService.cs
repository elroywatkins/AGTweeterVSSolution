using AG.Common;
using System;
using System.Collections.Generic;

namespace AG.BLL
{
    public class TweeterService
    {
        private ILogger Logger;
        public TweeterService(ILogger logger = null)
        {
            //default to Console Logger
            Logger = logger;
        }

        public IList<TweetStructure> GetTweetsByAllUsers()
        {
            return null;
        }

    }
}
