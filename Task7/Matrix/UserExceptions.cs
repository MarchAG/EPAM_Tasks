using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix
{
    class MatrixArgumentExceprions : Exception
    {
        public MatrixArgumentExceprions()
            :base()
        {
        }

        public MatrixArgumentExceprions(string message)
            :base(message)
        {
        }

        public MatrixArgumentExceprions(string message, Exception inner)
            :base(message, inner)
        {
        }
    }
}
