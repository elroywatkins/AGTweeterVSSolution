using Microsoft.VisualStudio.TestTools.UnitTesting;
using AG.BLL;
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
            BLL.TweeterService tweeterService = new BLL.TweeterService(consoleLogger);
            Assert.IsNotNull(tweeterService.GetTweetsByAllUsers());
        }
    }
}
