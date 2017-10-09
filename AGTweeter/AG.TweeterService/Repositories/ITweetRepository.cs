using AG.Common;
using System.Collections.Generic;

namespace AG.TweeterBLL
{
    public interface ITweetRepository
    {
        IList<Tweet> GetAllTweets();
        IList<Tweet> GetTweetsByUserName(string userName);
    }
}