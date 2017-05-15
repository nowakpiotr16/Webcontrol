using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Webcontrol;

namespace WebControlTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AssertStringPutInBetween()
        {
            Assert.AreEqual("milky", UrlUtilities.PutAfterOrAtStart("milk", "lk", "y"));
        }

        [TestMethod]
        public void AssertStringPutAtStart()
        {
            Assert.AreEqual("wotstest", UrlUtilities.PutAfterOrAtStart("test", "wo", "ts"));
        }

        [TestMethod]
        public void AssertAddPrefixes()
        {
            Assert.AreEqual("http://www.google.com", UrlUtilities.AddPrefixes("google.com"));
        }
    }
}
