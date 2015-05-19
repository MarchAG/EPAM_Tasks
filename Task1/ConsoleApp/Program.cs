using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatForString;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Formatting cl = new Formatting();
            string[] replacedCoordinates = new string[3];
            FileStream file1 = new FileStream("H:\\file1.txt", FileMode.Open);
            Console.WriteLine(Formatting.Format(file1));

        }
    }
}
