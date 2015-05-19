using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathCalculation;

namespace Newton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MathCalculator.Root(-27,2));
            Console.WriteLine(Math.Pow(27, 1 / 3.0));
            Console.WriteLine(MathCalculator.ConvertToBin(10));
        }
    }
}
