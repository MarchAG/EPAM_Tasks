using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVectorAndPolynomial
{
    /// <summary>
    /// Class for working with vectors
    /// </summary>
    public class Vector
    {
        private double[] vect;//set get clone
        static int countOfVectors = 0;

        public double[] Vect
        {
            get
            {
                return (double[])vect.Clone();
            }
            set
            {
                //
                vect = (double[])value.Clone();
            }
        }
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= vect.Length)
                    throw new IndexOutOfRangeException(Resource1.IndexOutOfRangeExceptionString);
                return vect[i];
            }
            set
            {
                if (i < 0 || i >= vect.Length)
                    throw new IndexOutOfRangeException(Resource1.IndexOutOfRangeExceptionString);
                vect[i] = value;
            }
        }
        public int Size
        {
            get
            {
                return vect.Length;
            }
        }
        /// <summary>
        /// Constructor of Vector
        /// </summary>
        /// <param name="array">array of values vector</param>
        public Vector (double[] array)
        {
            //null
            countOfVectors++;
            vect = new double[array.Length];//
            for (int i = 0; i < array.Length; i++)
            {
                vect[i] = array[i];
            }
        }
        /// <summary>
        /// adds two vectors
        /// </summary>
        /// <param name="vect1">1 vector</param>
        /// <param name="vect2">2 vector</param>
        /// <returns>sum of vectors</returns>
        public static Vector operator +(Vector vect1, Vector vect2)
        {
            //null
            if (vect1 == null || vect2 == null)
                throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
            if (vect1.Size != vect2.Size)
                throw new ArgumentException(Resource1.ArgumentExceptionString);//
            double[] result = new double[vect1.Size];
            for (int i = 0; i < vect1.Size; i++)
            {
                result[i] = vect1[i] + vect1[i];
            }
            return new Vector(result);
        }
        /// <summary>
        /// vector difference
        /// </summary>
        /// <param name="vect1">1 vector</param>
        /// <param name="vect2">2 vector</param>
        /// <returns>difference</returns>
        public static Vector operator -(Vector vect1, Vector vect2)
        {
            //
            if (vect1.Size != vect2.Size)
                throw new ArgumentException(Resource1.ArgumentExceptionString);
            double[] result = new double[vect1.Size];
            for (int i = 0; i < vect1.Size; i++)
            {
                result[i] = vect1[i] - vect1[i];
            }
            return new Vector(result);
        }

        //a × b = {aybz - azby; azbx - axbz; axby - aybx}
        /// <summary>
        /// Vector product
        /// </summary>
        /// <param name="vect1">1 vector</param>
        /// <param name="vect2">2 vector</param>
        /// <returns>Vector product</returns>
        public static Vector operator *(Vector vect1, Vector vect2)
        {
            if (vect1.Size != vect2.Size || vect1.Size != 3)
                throw new ArgumentException(Resource1.ArgumentExceptionString);//
            double[] result = new double[vect1.Size];
            result[0] = vect1[1] * vect2[2] - vect1[2] * vect2[1];
            result[1] = vect1[2] * vect2[0] - vect1[0] * vect2[2];
            result[2] = vect1[0] * vect2[1] - vect1[1] * vect2[0];
            return new Vector(result);
        }
        /// <summary>
        /// angle of two vectors
        /// </summary>
        /// <param name="vect1">1 vector</param>
        /// <param name="vect2">2 vector</param>
        /// <returns>cosine of the angle between the vectors</returns>
        public static double operator ^(Vector vect1, Vector vect2)
        {
            if (vect1.Size != vect2.Size)
                throw new ArgumentException(Resource1.ArgumentExceptionString);//
            double numerator = 0;
            double denominator1 = 0;
            double denominator2 = 0;
            for (int i = 0; i < vect1.Size; i++)
            {
                numerator += vect1[i] * vect2[i];
                denominator1 += vect1[i] * vect1[i];
                denominator2 += vect2[i] * vect2[i];
            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);
            //0
            if (denominator1 == 0 || denominator2 == 0)
                throw new DivideByZeroException(Resource1.DivideByZeroExceptionString);
            return (numerator / (denominator1 * denominator2));
        }
    }
}
