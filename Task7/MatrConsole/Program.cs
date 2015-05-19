using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMatrix;

namespace MatrConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrixArray = new double[2, 2]
            {
                {5,7},
                {9,6}
            };
            double[,] matrArr2 = new double[2, 2]
            {
                {5,5},
                {9,6}
            };
            double[,] matrixArray3 = new double[2, 2]
            {
                {2,5},
                {7,9}
            };
            Matrix matrix1 = new Matrix(matrixArray);
            Matrix matrix2 = new Matrix(matrArr2);
            Matrix matrix3 = new Matrix(2, 2);
            matrix3.Matr = matrixArray3;
            matrixArray3[1, 1] = 5;
            Console.WriteLine(matrix3[1,1]);
            Console.WriteLine(matrix1.CompareTo(matrix2));
        }
    }
}
