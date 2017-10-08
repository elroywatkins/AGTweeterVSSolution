using System;
using System.Collections.Generic;

namespace AG.Common
{
    public class TweetStructure : ITweetStructure
    {
        public User user;
        public IList<UserTweets> userTweets;
    }

}
