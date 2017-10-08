using System;
using System.Collections.Generic;
using AG.Common;
using AG.TweeterDAL;

namespace AG.TweeterBLL
{
    public class TweeterService
    {
        private ILogger Logger;
        private IDataSource UsersData;
        private IDataSource TweetsData;

        public TweeterService(ILogger logger, IDataSource usersData, IDataSource tweetsData)
        {
            Logger = logger;
            UsersData = usersData;            
            TweetsData = tweetsData;
        }

        public IList<TweetStructure> GetTweetsByAllUsers()
        {
            if (!DataSourcesAreValid())
                return null;

            return null;
        }

        private bool DataSourcesAreValid()
        {
            bool result = false;
            if (!DataSourceIsValid(UsersData))
            {
                throw new Exception("User Data Source is Invalid");
            }

            if (!DataSourceIsValid(TweetsData))
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
