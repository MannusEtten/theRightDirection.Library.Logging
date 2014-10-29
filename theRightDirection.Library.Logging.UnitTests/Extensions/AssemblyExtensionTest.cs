using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using theRightDirection.Library.Extensions;
using FluentAssertions;
using System.IO;
namespace theRightDirection.Library.UnitTests.Extensions
{
    [TestClass]
    public class AssemblyExtensionTest
    {
        [TestMethod]
        public void FindFileNextToAssembly_Suppress_Exception_Gives_StringEmpty()
        {
            var fileName = Assembly.GetExecutingAssembly().FindFileNextToAssembly("Testje.txt", true);
            fileName.ShouldBeEquivalentTo(string.Empty);
        }

        [TestMethod]
        public void FindFileNextToAssembly_Gives_Exception()
        {
            Action act = () => Assembly.GetExecutingAssembly().FindFileNextToAssembly("Testje.txt");
            act.ShouldThrow<FileNotFoundException>();
        }

        [TestMethod]
        public void FindFileNextToAssembly_Is_Okay()
        {
            var fileName = Assembly.GetExecutingAssembly().FindFileNextToAssembly("675a1ed5-6333-44e8-ac23-d08b1c5be477.xml");
            fileName.Should().Contain("675a1ed5-6333-44e8-ac23-d08b1c5be477");
        }
    }
}
