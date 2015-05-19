using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVectorAndPolynomial;

namespace ConsoleVectAndPolynom
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vect1 = new Vector(new double[] { 3, 5, 2 });
            Vector vect2 = new Vector(new double[] { 7, 1, 1 });
            double angle = vect1 ^ vect2;
            Polynomial pol1 = new Polynomial(new double[] { -1, -3, 7, 4 });
            Polynomial pol2 = new Polynomial(new double[] { -1, -3, 7, 4 });
            Console.WriteLine((string)pol1);
            Console.WriteLine(pol1.GetHashCode());
            Console.WriteLine(pol2.GetHashCode());
            Console.WriteLine(angle);
            if (((Object)pol1).Equals((Object)pol2))
                Console.WriteLine("true");
        }
    }
}
