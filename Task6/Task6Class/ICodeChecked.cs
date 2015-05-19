using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Class
{

        public interface ICodeChecked
        {
            bool CodeCheckSyntax(string sourceCode, string lang);

        }
}
