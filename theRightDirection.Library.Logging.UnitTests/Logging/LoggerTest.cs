using theRightDirection.Library.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace theRightDirection.Library.UnitTests.Logging
{
    /// <summary>
    /// Summary description for LoggerTest
    /// </summary>
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void LogDebug()
        {
            ILogger logger = Logger.GetLogger();
            logger.LogDebug("mannus");
        }

        [TestMethod]
        public void LogDebugWithFormat()
        {
            ILogger logger = Logger.GetLogger();
            logger.LogDebug("{0}:{1}", "mannus", "etten");
        }

        [TestMethod]
        public void LogDebugInternal()
        {
            string result = LogDebugInternalMethod("{0}:{1}", "mannus", "etten");
            Assert.AreEqual("mannus:etten", result);
        }

        private string LogDebugInternalMethod(string format, params string[] values)
        {
            string message = string.Format(format, values);
            return message;
        }
    }
}