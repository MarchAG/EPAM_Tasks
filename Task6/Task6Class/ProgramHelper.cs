using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6Class
{
    public class ProgramHelper : ProgramConverter, ICodeChecked
    {

        public bool CodeCheckSyntax(string sourceCode, string lang)
        {
            if (lang == "VB" && ConvertToVB(sourceCode) == sourceCode)
                return true;
            else if (lang == "Sharp" && ConvertToSharp(sourceCode) == sourceCode)
                return true;
            return false;
        }
    }
}
