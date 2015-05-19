using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFIleReader;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader r = new Reader(@"d:\Text.txt", "1234");
        }
    }
}
