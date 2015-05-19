using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVectorAndPolynomial;

namespace UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod11()
        {
            Polynomial polynom1 = new Polynomial(new double[] { 1, 1, 1 });
            Polynomial polynom2 = new Polynomial(new double[] { 2, 1, 1 });
            Assert.IsFalse(polynom1 == polynom2);
        }

        [TestMethod]
        public void TestMethod12()
        {
            Polynomial polynom1 = new Polynomial(new double[] { 1, 1, 1 });
            Polynomial polynom2 = new Polynomial(new double[] { 1, 1, 1 });
            Assert.IsTrue(polynom1 == polynom2);
        }

        [TestMethod]
        public void TestMethod13()
        {
            Polynomial polynom1 = new Polynomial(new double[] { 2, 1, 1  });
            Polynomial polynom2 = new Polynomial(new double[] { 1, 1, 1  });
            Assert.IsTrue(polynom1 > polynom2);
        }
        [TestMethod]
        public void TestMethod14()
        {
            Polynomial polynom1 = new Polynomial(new double[] { 1, 1, 1 });
            Polynomial polynom2 = new Polynomial(new double[] { 1, 2, 1 });
            Assert.IsTrue(polynom1 < polynom2);
        }

        [TestMethod]
        public void TestMethod15()
        {
            Polynomial polynom1 = new Polynomial(new double[] { 1, 1, 1 });
            Polynomial polynom2 = new Polynomial(new double[] { 1, 2, 1 });
            Assert.IsTrue(polynom1 != polynom2);
        }

        [TestMethod]
        public void TestMethod16()
        {
            string actual = "(-1)X^1 + (1)";
            Polynomial polynom1 = new Polynomial(new double[] { -1, 1 });
            Assert.AreEqual(actual, ((string)polynom1));
        }
    }
}
