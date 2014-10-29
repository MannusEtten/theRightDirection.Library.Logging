using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using theRightDirection.Library.Extensions;

namespace theRightDirection.Library.UnitTests.Extensions
{
    [TestClass]
    public class DateTimeExtensionTest
    {
        [TestMethod]
        public void CreateTimeStamp_For_13012011_095810()
        {
            DateTime dt = new DateTime(2011, 1, 13, 10, 55, 14);
            Assert.AreEqual(1294912514000, dt.TimeStampInMilliseconds());
        }
    }
}