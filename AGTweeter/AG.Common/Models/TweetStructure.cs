using System;
using System.Collections.Generic;

namespace AG.Common
{
    public class TweetStructure : ITweetStructure
    {
        public User Tweeter;
        public IList<Tweet> UserTweets;
    }

}
