using AG.Common;
using System.Collections.Generic;
using System.Linq;
using System;
using AG.TweeterDAL;

namespace AG.TweeterBLL
{
    public class TweetRepository : ITweetRepository
    {
        private IList<Tweet> AllTweets;
        private ILogger Logger;        

        public TweetRepository(IDataSource tweetDataSource,IUserRepository userRepository, ILogger logger)
        {
            Logger = logger;
            AllTweets = MapTweetDataSourceToTweets(tweetDataSource,userRepository);
        }

        //Main method to interpret dictionary into list of tweets
        private IList<Tweet> MapTweetDataSourceToTweets(IDataSource tweetDataSource, IUserRepository userRepository)
        {
            var resultTweetList = new List<Tweet>();
            string delimiter = AG.TweeterService.ServiceSettings.FileDelimiterTweet;
            int lineNumber = 0;
            var itemString = "";
            foreach (KeyValuePair<int, string> tweetItem in tweetDataSource.GetData())
            {
                // find delimiter postion
                lineNumber = tweetItem.Key;
                itemString = tweetItem.Value;
                var chrIdx = itemString.IndexOf(delimiter);
                if (chrIdx == -1)
                {
                    Logger.LogError("Delimeter for tweets not found in file");
                    continue;
                }
                //extract user name
                string userName = itemString.Substring(0, chrIdx).Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    Logger.LogError("No username in file");
                    continue;
                }

                //extract the tweets from the rest of the string                
                var strLength = itemString.Length - chrIdx - delimiter.Length - 1;
                string message = itemString.Substring(chrIdx + delimiter.Length + 1, strLength);
                if (string.IsNullOrEmpty(message))
                {
                    Logger.LogError("No tweet in file");
                    continue;
                }

                var user = userRepository.GetUserByName(userName);
                if (user == null)
                {
                    user = new User() { Name = userName };
                }

                //add to tweet object
                var tweet = new Tweet()
                {
                    Tweeter = user,
                    Message = message.Trim(),
                    MessageOrder = lineNumber
                };

                resultTweetList.Add(tweet);
            }

            return resultTweetList;
        }
      
        //retrieval methods
        public IList<Tweet> GetAllTweets()
        {
            return AllTweets;
        }

        public IList<Tweet> GetTweetsByUserName(string userName)
        {
            return AllTweets.Where(u => u.Tweeter.Name == userName).ToList();
        }
    }
}