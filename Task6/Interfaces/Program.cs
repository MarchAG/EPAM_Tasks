using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6Class;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] mass = new ProgramConverter[2];
            mass[0] = new ProgramHelper();
            Console.WriteLine(mass[0] is ICodeChecked);
            Console.WriteLine(mass[1] is ICodeChecked);
        }
    }
}
