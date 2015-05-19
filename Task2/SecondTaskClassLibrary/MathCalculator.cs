using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCalculation
{
    /// <summary>
    /// Class to calcule Root of number and for convert number
    /// </summary>
    public class MathCalculator
    {
        /// <summary>
        /// Calculate the root of number by Newton method
        /// </summary>
        /// <param name="A">number for calculating</param>
        /// <param name="n">degree of root</param>
        /// <param name="E">accuracy of method</param>
        /// <returns>Root of number</returns>
        static public double Root(double A, int n, double E = 0.0001)
        {
            if (A < 0 && n % 2 == 0)
                    throw new ArgumentException(Resource1.ArgumenExceptionString);
            if (n == 0)
                throw new ArgumentException(Resource1.ArgumenExceptionString);
            if (A == 1)
                return 1;
            double xi = A;
            double x0 = A;
            do
            {
                x0 = xi;
                xi = (1.0 / n) * ((n - 1) * x0 + (A /Math.Pow(x0, n - 1)) );
            } while (Math.Abs(xi - x0) > E);
            return xi;
        }
        /// <summary>
        /// Calculate root of number by standart method
        /// </summary>
        /// <param name="A">number for calculating</param>
        /// <param name="n">degree of root</param>
        /// <returns></returns>
        static public double StandartRoot(double A, int n)
        {
            if (A < 0 && n % 2 == 0)
                throw new ArgumentException(Resource1.ArgumenExceptionString);//res
            if (n == 0)
                throw new ArgumentException(Resource1.ArgumenExceptionString);
            if (A == 1)
                return 1;
            return Math.Pow(A, 1.0 / n);
        }
        /// <summary>
        /// Сompares two methods for calculating the root
        /// </summary>
        /// <param name="A">number for calculating</param>
        /// <param name="n">degree of root</param>
        /// <returns></returns>
        static public double Compare(double A, int n)
        {
            return Math.Abs(Root(A, n) - StandartRoot(A, n));
        }
        /// <summary>
        /// converts the number into a binary representation
        /// </summary>
        /// <param name="n">number to be converted</param>
        /// <returns>the binary representation of the number</returns>
        static public string ConvertToBin(uint n)
        {
            return Convert.ToString(n, 2);
        }
    }
}
