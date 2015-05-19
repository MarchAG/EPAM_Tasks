using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expected = 16;
            int actual = NODClassLibrary.NOD.Stain(16, 32);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int expected = 5;
            int actual = NODClassLibrary.NOD.Stain(-15, -25);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int expected = 21;
            int actual = NODClassLibrary.NOD.Stain(441, 42);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            int expected = 21;
            int actual = NODClassLibrary.NOD.Euclidean(1071, 462);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            int expected = 6;
            int actual = NODClassLibrary.NOD.Euclidean(36, 60, 42);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            int expected = 12;
            int actual = NODClassLibrary.NOD.Euclidean(168, 180, 48, 3024);
            Assert.AreEqual(expected, actual);
        }
    }
}
