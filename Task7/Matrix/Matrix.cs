using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix
{
    
    /// <summary>
    /// Class for working with Matrix
    /// </summary>
    public class Matrix : IComparable
    {
        private double[,] matr;

        public double[,] Matr
        {
            get
            {
                return (double[,])matr.Clone();
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
                matr = (double[,])value.Clone();
            }
        }

        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= matr.Length || j < 0 || j >= matr.GetLength(1))
                    throw new IndexOutOfRangeException();
                return matr[i,j];
            }
            set
            {
                if (i < 0 || i >= matr.Length || j < 0 || j >= matr.GetLength(1))
                    throw new IndexOutOfRangeException();
                matr[i,j] = value;
            }
        }

        public int SizeN
        {
            get
            {
                return matr.GetLength(0);
            }
        }

        public int SizeM
        {
            get
            {
                return matr.GetLength(1);
            }
        }

        /// <summary>
        /// Constructor of matrix
        /// </summary>
        /// <param name="n">Number of rows</param>
        /// <param name="m">Number of columns</param>
        public Matrix(int n, int m)
        {
            if(n < 0 || m < 0)
                throw new MatrixArgumentExceprions(Resource1.ArgumentExceptionString);
            matr = new double[n,m];
            for (int i = 0; i < n; i++)
			     for (int j = 0; j < m; j++)
			        matr[i,j] = 0;
        }
        /// <summary>
        /// Constructor of matrix
        /// </summary>
        /// <param name="array">array for filling the matrix</param>
        public Matrix(double[,]  array)
        {
            if (array == null)
                throw new MatrixArgumentExceprions(Resource1.ArgumentExceptionString);
            matr = (double[,])array.Clone();
        }

        /// <summary>
        /// Compares the currents instance with another matrix
        /// </summary>
        /// <param name="obj">An object to compare with this instance</param>
        /// <returns>A value that indicates the relative order of the matrix being compared.</returns>
        public int CompareTo(object obj)
        {
            Matrix matrix = obj as Matrix;
            if (matrix == null)
                throw new ArgumentException(Resource1.ArgumentExceptionString);
            if(this.SizeN != matrix.SizeN || this.SizeM != matrix.SizeM)
                throw new ArgumentException(Resource1.ArgumentExceptionString);
            for (int i = 0; i < this.SizeN; i++)
            {
                for (int j = 0; j < this.SizeM; j++)
                {
                    if (this[i, j] < matrix[i, j])
                        return -1;
                    if (this[i, j] > matrix[i, j])
                        return 1;
                }
            }
            return 0;
        }

        public static Matrix operator +(Matrix matr1, Matrix matr2)
        {
            if (matr1 == null || matr2 == null)
                throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
            if (matr1.SizeN != matr2.SizeN || matr1.SizeM != matr2.SizeM)
                throw new ArgumentException(Resource1.ArgumentExceptionString);
            double[,] matrix = new double[matr1.SizeN, matr1.SizeM];
            for (int i = 0; i < matr1.SizeN; i++)
            {
                for (int j = 0; j < matr2.SizeM; j++)
                {
                    matrix[i,j] = matr1[i, j] + matr2[i, j];
                }
            }
            return new Matrix(matrix);
        }

        public static Matrix operator -(Matrix matr1, Matrix matr2)
        {
            if (matr1 == null || matr2 == null)
                throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
            if (matr1.SizeN != matr2.SizeN || matr1.SizeM != matr2.SizeM)
                throw new ArgumentException(Resource1.ArgumentExceptionString);
            double[,] matrix = new double[matr1.SizeN, matr1.SizeM];
            for (int i = 0; i < matr1.SizeN; i++)
            {
                for (int j = 0; j < matr2.SizeM; j++)
                {
                    matrix[i, j] = matr1[i, j] - matr2[i, j];
                }
            }
            return new Matrix(matrix);
        }

        public static Matrix operator *(Matrix matr1, Matrix matr2)
        {
            if (matr1 == null || matr2 == null)
                throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
            if (matr1.SizeM != matr2.SizeN)
                throw new ArgumentException(Resource1.ArgumentExceptionString);
            double[,] matrix = new double[matr1.SizeN, matr2.SizeM];
            double buf = 0;
            for (int i = 0; i < matr1.SizeN; i++)
            {
                for (int j = 0; j < matr2.SizeN; j++)
                {
                    buf = 0;
                    for (int k = 0; k < matr1.SizeM; k++)
                        buf += matr1[i, k] * matr2[k, j];
                    matrix[i, j] = buf;
                }
            }
            return new Matrix(matrix);
        }
    }
}
