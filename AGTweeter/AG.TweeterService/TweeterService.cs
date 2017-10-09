using System;
using System.Collections.Generic;
using AG.Common;
using AG.TweeterDAL;
using System.Linq;

namespace AG.TweeterBLL
{
    public class TweeterService
    {
        private ILogger Logger;
        private IDataSource UsersDataSource;
        private IDataSource TweetsDataSource;
        //private UserRepository UserRepository;
        //private TweetRepository TweetRepository;

        public TweeterService(ILogger logger, IDataSource usersDataSource, IDataSource tweetsDataSource)
        {
            Logger = logger;
            UsersDataSource = usersDataSource;            
            TweetsDataSource = tweetsDataSource;
        }

        public IList<TweetStructure> GetTweetsByAllUsers()
        {
            if (!DataSourcesAreValid())
                return null;

            //initialise repositories
            var userRepository = new UserRepository(UsersDataSource, Logger);            
            var tweetRepository = new TweetRepository(TweetsDataSource,userRepository,Logger);

            var tweetStructureList = new List<TweetStructure>();
            var userList = userRepository.GetAllUsers();
            
            //loop through repositories 
            foreach (var user in userList)
            {
                var tweetStructure = new TweetStructure()
                {
                    Tweeter = user,
                    UserTweets = new List<Tweet>()
                };

                //Get All tweets for user
                var tweets = tweetRepository.GetTweetsByUserName(user.Name);
                
                //if user has followers add their tweets
                if (user.Followees != null)
                {
                    IList<Tweet> followeeTweets = new List<Tweet>();
                    foreach (var follower in user.Followees)
                    {
                        foreach (var tweet in tweetRepository.GetTweetsByUserName(follower.Name))
                        {
                            followeeTweets.Add(tweet);
                        }
                    }

                    //add follower tweets
                    if (followeeTweets.Count > 0)
                    {
                        foreach (var tweet in followeeTweets)
                        {
                            tweets.Add(tweet);
                        }
                    }
                }

                //add all tweets to tweet structure
                
                foreach (var tweet in tweets)
                {
                    tweetStructure.UserTweets.Add(tweet);
                }

                tweetStructureList.Add(tweetStructure);
            }
            return tweetStructureList;
        }

        private bool DataSourcesAreValid()
        {
            bool result = false;
            if (!DataSourceIsValid(UsersDataSource))
            {
                throw new Exception("User Data Source is Invalid");
            }

            if (!DataSourceIsValid(TweetsDataSource))
            {
                throw new Exception("Tweets Data Source is Invalid");
            }
            result = true;
            return result;
        }

        private bool DataSourceIsValid(IDataSource dataSource)
        {                        
            bool result = false;
            if (dataSource == null)
            {
                var ex = new Exception($"{dataSource.GetType().Name} data is null");
                Logger.LogError(ex.Message);
                return result;
            }

            try
            {
                var ds = dataSource.GetData();
                if (ds == null)
                {
                    var ex = new Exception($"{dataSource.GetType().Name} data is null");
                    Logger.LogError(ex.Message);
                    return result;
                }

                if (ds.Count <= 0)
                {
                    var ex = new Exception($"{dataSource.GetType().Name} data is empty");
                    Logger.LogError(ex.Message);
                    return result;
                }
                result = true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error occurred loading { dataSource.GetType().Name} structure", ex);
                throw ex;
            }

            return result;
        }

    }
}
