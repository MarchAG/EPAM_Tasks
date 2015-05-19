using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVectorAndPolynomial;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            Vector vect1 = new Vector(new double[] { 3, 2, 1 });
            Vector vect2 = new Vector(new double[] { 3, 2, 1 });
            Vector expected = vect1 + vect2;
            Vector actual = new Vector(new double[]{6,4,2});
            Assert.AreEqual(actual[2], expected[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {
            Vector vect1 = new Vector(new double[] { 3, 2, 1 });
            Vector vect2 = new Vector(new double[] { 3, 2, 1, 4, 5 });
            Vector expected = vect1 + vect2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod3()
        {
            Vector vect1 = new Vector(new double[] { 3, 2, 1 });
            Vector vect2 = new Vector(new double[] { 3, 2, 1, 4, 5 });
            Vector expected = vect1 - vect2;
        }

        [TestMethod]
        public void TestMethod4()
        {
            Vector vect1 = new Vector(new double[] { 3, 2, 1 });
            Vector vect2 = new Vector(new double[] { 1, 2, 3 });
            double actual = 5.0 / 7;
            double expected = vect1 ^ vect2;
            Assert.AreEqual(actual,expected);
        }
    }
}
