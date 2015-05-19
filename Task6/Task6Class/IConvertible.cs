using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Class
{
        public interface IConvertible
        {
            string ConvertToSharp(string VBCode);
            string ConvertToVB(string SharpCode);
        }
}
