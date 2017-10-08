using AG.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AG.TweeterConsoleApp.Tests
{
    [TestClass]
    public class PrintingTests
    {
        [TestMethod]
        public void TweetProcessorExpectedOutput()
        {
            
            User userJon = new User(){ Name = "Jon Snow" };
            User userDany = new User() { Name = "Daenerys of the House Targaryen, the First of Her Name, The Unburnt, Queen of the Andals, the Rhoynar and the First Men, Queen of Meereen, Khaleesi of the Great Grass Sea, Protector of the Realm, Lady Regnant of the Seven Kingdoms, Breaker of Chains and Mother of Dragons" };
            User userTyrion = new User() { Name = "Tyrion Lannister" };

            userJon.Followers.Add((Follower)userDany);
            userJon.Followers.Add((Follower)userTyrion);

            userDany.Followers.Add((Follower)userJon);
            userDany.Followers.Add((Follower)userTyrion);

            var mockUsers = new List<User>()
            {
                userJon, userDany, userTyrion
            };

            var mockTweets = new List<UserTweets>();
            mockTweets.Add(new UserTweets() { User = userJon, Tweet = "Its getting a little cold this side.",TweetOrder = 1});
            mockTweets.Add(new UserTweets() { User = userJon, Tweet = "Hope the cold doesn't last too long.",TweetOrder = 2 });
            mockTweets.Add(new UserTweets() { User = userTyrion, Tweet = "I Love winter.",TweetOrder = 3 });
            mockTweets.Add(new UserTweets() { User = userDany, Tweet = "Winter Is Comming.", TweetOrder = 4 });
            mockTweets.Add(new UserTweets() { User = userDany, Tweet = "I Have Dragons", TweetOrder = 4 });

            
        }
    }
}
