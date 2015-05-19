using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMatrix;

namespace UnitTestsForMatriix
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Matrix matrix = new Matrix(3, 3);
            double expected = matrix[2, 2];
            double actual = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            double[,] matrixArray = new double[3, 2]
            {
                {1,2},
                {3,4},
                {5,6}
            };
            double[,] matrArr2 = new double[2, 2]
            {
                {5,7},
                {9,6}
            };
            Matrix matrix1 = new Matrix(matrixArray);
            Matrix matrix2 = new Matrix(matrArr2);
            Matrix matrix3 = matrix1 * matrix2;
            double actual = 51;
            double expected = matrix3[1, 0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            double[,] matrixArray = new double[2, 2]
            {
                {1,2},
                {3,4}
            };
            double[,] matrArr2 = new double[2, 2]
            {
                {5,7},
                {9,6}
            };
            Matrix matrix1 = new Matrix(matrixArray);
            Matrix matrix2 = new Matrix(matrArr2);
            Matrix matrix3 = matrix1 + matrix2;
            double actual = 6;
            double expected = matrix3[0, 0];
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            double[,] matrixArray = new double[2, 2]
            {
                {5,7},
                {9,6}
            };
            double[,] matrArr2 = new double[2, 2]
            {
                {5,7},
                {9,6}
            };
            Matrix matrix1 = new Matrix(matrixArray);
            Matrix matrix2 = new Matrix(matrArr2);
            int actual = 0;
            int expected = matrix1.CompareTo(matrix2);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod5()
        {
            double[,] matrArr2 = new double[2, 2]
            {
                {5,7},
                {9,6}
            };
            //Matrix matrix1 = new Matrix(matrixArray);
            Matrix matrix2 = new Matrix(matrArr2);
            Matrix matrix1 = null;
            matrix2.CompareTo(matrix1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMethod6()
        {
            double[,] matrArr2 = new double[2, 2]
            {
                {5,7},
                {9,6}
            };
            //Matrix matrix1 = new Matrix(matrixArray);
            Matrix matrix2 = new Matrix(matrArr2);
            Matrix matrix1 = null;
            Matrix matrix3 = matrix1 + matrix2;
        }
    }
}
