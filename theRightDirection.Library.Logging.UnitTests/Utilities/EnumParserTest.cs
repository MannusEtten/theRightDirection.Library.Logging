using System;
using theRightDirection.Library.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace theRightDirection.Library.UnitTests.Utilities
{
    [TestClass]
    public class EnumParserTest
    {
        [TestMethod]
        public void TryParseTextToEnumValue_With_Invalid_Value_Is_False()
        {
            DonaldDuck duck;
            var result = EnumHelper.TryParseTextToEnumValue<DonaldDuck>("Mannus", out duck);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParseTextToEnumValue_With_Valid_Value_Is_True()
        {
            DonaldDuck duck;
            var result = EnumHelper.TryParseTextToEnumValue<DonaldDuck>("Kwek", out duck);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ParseTextToEnumValue_With_EnumDonaldDuck_Value_Kwek()
        {
            DonaldDuck value = EnumHelper.ParseTextToEnumValue<DonaldDuck>("Kwek");
            Assert.AreEqual(DonaldDuck.Kwek, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTextToEnumValue_With_EnumDonaldDuck_Value_kwak_Expect_ArgumentException()
        {
            DonaldDuck value = EnumHelper.ParseTextToEnumValue<DonaldDuck>("kwak");
        }
    }

    public enum DonaldDuck
    {
        Kwik,
        Kwek,
        Kwak
    }
}