using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace FormatForString//
{
    /// <summary>
    /// Class for working with a formating strings
    /// </summary>
    public class Formatting//
    {
        /// <summary>
        /// Validate string
        /// </summary>
        /// <param name="str">string to check</param>
        /// <returns>Is valid</returns>
        static public bool IsValid(string str)
        {
            //
            string pattern = @"^\d+\.\d+,\d+\.\d+";
            return Regex.IsMatch(str, pattern);
        }
        /// <summary>
        /// format string from file
        /// </summary>
        /// <param name="file">file with coordinates</param>
        /// <returns>formated string</returns>
        static public string Format(FileStream file)
        {
            if (file == null)
                throw new ArgumentNullException();//res
            StringBuilder str = new StringBuilder();
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                    str.Append(Format(reader.ReadLine()) + "\n");
            }
            return str.ToString();
        }
        /// <summary>
        /// format string
        /// </summary>
        /// <param name="coordinates">coordinates</param>
        /// <returns>formated string</returns>
        static public string Format(string coordinates)
        {
            if (!IsValid(coordinates))
                return null;
            string[] parts = coordinates.Replace(",", " ").Replace(".", ",").Split(' ');
            return String.Format("X: {0} Y: {1}", parts[0], parts[1]);
        }
    }
}
