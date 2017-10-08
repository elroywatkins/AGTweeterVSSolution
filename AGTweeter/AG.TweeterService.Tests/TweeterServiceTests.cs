using Microsoft.VisualStudio.TestTools.UnitTesting;
using AG.TweeterBLL;
using AG.Common;
using AG.Common.Models.Logger;

namespace AG.TweeterService.Tests
{
    [TestClass]
    public class TweeterServiceTests
    {
        [TestMethod]
        public void GetTweetsByAllUsersTest()
        {
            ILogger consoleLogger = new ConsoleLogger();
            TweeterBLL.TweeterService tweeterService = new TweeterBLL.TweeterService(consoleLogger);
            Assert.IsNotNull(tweeterService.GetTweetsByAllUsers());
        }
    }
}
