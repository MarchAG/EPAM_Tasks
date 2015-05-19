using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Class
{
    public class ProgramConverter : IConvertible
    {
        public string ConvertToSharp(string VBCode)
        {
            return "Source string converted to C#";
        }

        public string ConvertToVB(string SharpCode)
        {
            return "Source string converted to VB";
        }
    }
}
