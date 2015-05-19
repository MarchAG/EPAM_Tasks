using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleClass;

namespace UnitTestForTriangles
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TestMethod1()
        {
            double[] sides = new double[3] { -4, 8, 10 };
            Triangle triangle = new Triangle(sides);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TestMethod2()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(3, 3);
            Triangle triangle = new Triangle(point1, point2, point3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            double actual = 22;
            double[] sides = new double[3] { 4, 8, 10 };
            Triangle triangle = new Triangle(sides);
            double expected = triangle.Perimeter();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestMethod4()
        {
            double[] sides = new double[3] { 5, 5, 6 };
            Triangle triangle1 = new Triangle(sides);
            Triangle triangle2 = new Triangle(new double[3] { 6, 5, 5 });
            Assert.IsTrue(triangle1 == triangle2);
        }

        [TestMethod]
        public void TestMethod5()
        {
            double actual = 6;
            Triangle triangle2 = new Triangle(new double[3] { 3, 4, 5 });
            double expected = triangle2.Area();
            Assert.AreEqual(actual, expected);
        }
    }
}
