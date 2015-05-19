using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleClass;

namespace TriangleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] sides = new double[3] { 6, 5, 5 };
            Triangle triangle1 = new Triangle(sides);
            Triangle triangle2 = new Triangle(new double[3] { 6, 5, 5 });
            Console.WriteLine(triangle1.Area());
            Console.WriteLine(triangle2.Area());
            Console.WriteLine(triangle1.GetHashCode());
            Console.WriteLine(triangle2.GetHashCode());
        }
    }
}
