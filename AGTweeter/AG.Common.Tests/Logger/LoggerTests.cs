using Microsoft.VisualStudio.TestTools.UnitTesting;
using AG.Common.Models.Logger;

namespace AG.Common.Tests
{
    [TestClass]
    public class LoggerTests
    {        
        [TestMethod]
        public void ConsoleLoggerErrorTest()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Assert.IsNotNull(logger);
            logger.LogError("Testing Errror");            
        }
        [TestMethod]
        public void ConsoleLoggerInformationTest()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Assert.IsNotNull(logger);
            logger.LogInformation("Testing Information");
        }
        [TestMethod]
        public void ConsoleLoggerWarningTest()
        {
            ConsoleLogger logger = new ConsoleLogger();
            Assert.IsNotNull(logger);
            logger.LogWarning("Testing Warning");
        }
    }

}
