using Microsoft.VisualStudio.TestTools.UnitTesting;
using AG.TweeterBLL;
using AG.Common;
using AG.Common.Models.Logger;
using System.Collections.Generic;

namespace AG.TweeterService.Tests
{
    [TestClass]
    public class TweeterServiceTests
    {
        [TestMethod]
        [Ignore]
        public void GetTweetsByAllUsersTest()
        {
            ILogger consoleLogger = new ConsoleLogger();
            var tweeterService = new TweeterBLL.TweeterService(consoleLogger,null,null);
            Assert.IsNull(tweeterService);
        }

        [TestMethod]
        public void UserRepoGetUserByName()
        {
            ILogger consoleLogger = new ConsoleLogger();
            User userJon = new User() { Name = "Jon Snow" };
            User userDany = new User() { Name = "Daenerys of the House Targaryen, the First of Her Name, The Unburnt, Queen of the Andals, the Rhoynar and the First Men, Queen of Meereen, Khaleesi of the Great Grass Sea, Protector of the Realm, Lady Regnant of the Seven Kingdoms, Breaker of Chains and Mother of Dragons" };
            User userTyrion = new User() { Name = "Tyrion Lannister" };
            var userList = new List<User>() {userJon,userDany,userTyrion };
            
            IUserRepository users = new UserRepository(userList,consoleLogger);
            var user = users.GetUserByName("Jon Snow");
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Name, userJon.Name);            
        }

        [TestMethod]
        public void UserRepoGetUserByNameNotFound()
        {
            ILogger consoleLogger = new ConsoleLogger();
            User userJon = new User() { Name = "Jon Snow" };
            User userDany = new User() { Name = "Daenerys of the House Targaryen, the First of Her Name, The Unburnt, Queen of the Andals, the Rhoynar and the First Men, Queen of Meereen, Khaleesi of the Great Grass Sea, Protector of the Realm, Lady Regnant of the Seven Kingdoms, Breaker of Chains and Mother of Dragons" };
            User userTyrion = new User() { Name = "Tyrion Lannister" };
            var userList = new List<User>() { userJon, userDany, userTyrion };

            IUserRepository users = new UserRepository(userList, consoleLogger);
            var user = users.GetUserByName("Sir");
            Assert.IsNull(user);            
        }
    }
}
