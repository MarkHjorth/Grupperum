using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SuccesTest()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void FailedTest()
        {
            Assert.IsTrue(false);
        }
    }
}
