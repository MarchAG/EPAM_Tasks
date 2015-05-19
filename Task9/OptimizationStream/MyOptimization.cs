using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationStream
{
    /// <summary>
    /// Class fow working with file
    /// </summary>
    public class MyOptimization : FileStream
    {

        public MyOptimization(string path)
            : base(path, FileMode.Open, FileAccess.ReadWrite)
        {
        }

        /// <summary>
        /// Reads all text from file 
        /// </summary>
        /// <returns>all text</returns>
        public string MyReadAllFile()
        {
            using(StreamReader sr = new StreamReader(this))
            {
                return sr.ReadToEnd();
            }

        }

        /// <summary>
        /// Exchange a part of file
        /// </summary>
        /// <param name="position">position in the file</param>
        /// <param name="text">string to append</param>
        public void Rewrite(int position, string text)
        {
            int deleted = (int)this.Length - position - text.Length;
            this.SetLength(this.Length - deleted);
            using (StreamWriter sw = new StreamWriter(this))
            {
                this.Position = position;
                sw.Write(text);
            }
        }
    }
}
