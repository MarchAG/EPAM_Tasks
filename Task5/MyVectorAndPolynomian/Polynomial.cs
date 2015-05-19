using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVectorAndPolynomial
{
    /// <summary>
    /// class for working with polynomials
    /// </summary>
    public class Polynomial
    {
        private double[] polynom;//get set
        private int power;
        public double[] Polynom
        {
            get
            {
                return (double[])polynom.Clone();
            }
            set
            {
                //null
                polynom = (double[])value.Clone();
            }
        }
        public int Power
        {
            get 
            {
                return power;
            }
        }
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= polynom.Length)
                    throw new IndexOutOfRangeException(Resource1.IndexOutOfRangeExceptionString);
                return polynom[i];
            }
            set
            {
                if (i < 0 || i >= polynom.Length)
                    throw new IndexOutOfRangeException(Resource1.IndexOutOfRangeExceptionString);
                polynom[i] = value;
            }
        }
        /// <summary>
        /// Constructor of polynomial
        /// </summary>
        /// <param name="coef">array of coefficients of the polynomial</param>
        public Polynomial(double[] coef)
        {
            if (coef == null)
                throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
            power = coef.Length;
            polynom = new double[power];
            for (int i = 0; i < power; i++)
                polynom[i] = coef[i];
        }
        /// <summary>
        /// comparison operator of two polynomials
        /// </summary>
        /// <param name="pol1">first polynom</param>
        /// <param name="pol2">first polynom</param>
        /// <returns>result of comparison</returns>
        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals(pol1, null) && ReferenceEquals(pol2, null))
                return true;
            if (pol1.Power != pol2.Power)
                return false;
            if (!ReferenceEquals(pol1, null))
                return pol2.Equals(pol1);
            for (int i = 0; i < pol1.Power; i++)
                if (pol1[i] != pol2[i])
                    return false;

            return true;
        }

        public static bool operator >(Polynomial pol1, Polynomial pol2)
        {
            if (ReferenceEquals(pol1, null) || ReferenceEquals(pol2, null))
                throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
            if (pol1 == null || pol2 == null)
                throw new ArgumentNullException(Resource1.ArgumentNullExceptionString);
            if (pol1.Power > pol2.Power)
                return true;
            if (pol1.Power < pol2.Power)
                return false;

                for (int i = 0; i < pol1.Power; i++)
                    if (pol1[i] > pol2[i])
                        return true;
                return false;
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }
  

        public static bool operator <(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 > pol2) && pol1 != pol2;
        }
        /// <summary>
        /// explicit cast to string
        /// </summary>
        /// <param name="pol1">source polynomial</param>
        /// <returns>format string</returns>
        public static explicit operator string(Polynomial pol1)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < pol1.Power - 1; i++)
            {
                str.Append("(" + pol1[i] + ")" + "X^" +  (pol1.Power - 1 - i) + " + ");
            }
            str.Append("(" + pol1[pol1.Power - 1] + ")");
            return str.ToString();
        }
        /// <summary>
        /// overridden cast to string
        /// </summary>
        /// <returns>format string</returns>
        public override string ToString()
        {
            return (string)this;
        }
        /// <summary>
        /// overridden method of comparison
        /// </summary>
        /// <param name="pol1"></param>
        /// <returns></returns>
        public override bool Equals(Object pol1)
        {
            if (!(pol1 is Polynomial))
                throw new ArgumentException(Resource1.ArgumentExceptionString);
            return (this.ToString()).Equals(pol1.ToString());
        }
        /// <summary>
        /// overridden method of obtaining hash Code
        /// </summary>
        /// <returns>Hash code of object</returns>
        public override int GetHashCode()
        {
            return ((string)this).GetHashCode();
        }
    }
}
