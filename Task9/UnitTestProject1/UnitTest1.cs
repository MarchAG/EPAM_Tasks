using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimizationStream;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestMethod1()
        {
            MyOptimization myopt = new MyOptimization("dsad");
        }
    }
}
