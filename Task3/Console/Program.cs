using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NODClassLibrary;
using System.IO;

namespace Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = @"d:\tttsa.txt";
            FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Write);
            double res;
            Console.WriteLine(NOD.Euclidean(441, 21,out res));
            Console.WriteLine(res);
            Console.WriteLine(NOD.Stain(441, 21, out res));
            Console.WriteLine(res);
        }

    }
}
