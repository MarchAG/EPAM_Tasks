using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFIleReader
{
    /// <summary>
    /// Class for working with files
    /// </summary>
    public class Reader : FileStream
    {
        string password;
        static int readedPercents;

        public Reader(string path, string password)
            :base(path, FileMode.Open, FileAccess.Read)
        {
            if (password == null)
                throw new ArgumentNullException(ReaderExceptrions.ArgumentNullExceptionString);
            this.password = password;
            readedPercents = 0;
        }

        /// <summary>
        /// Сhecks for a match password
        /// </summary>
        /// <param name="pass">password for verification</param>
        /// <returns>Is correct password</returns>
        public bool IsCorrectPassword(string pass)
        {
            return this.password == pass;
        }
        
        private int PortionOfbytes(int portion)
        {
            return (int)this.Length * portion / 100;
        }

        /// <summary>
        /// Read a portion of bytes from a file
        /// </summary>
        /// <returns>String</returns>
        public string ReadNextPortion(int portionInPercents)//portion in %
        {
            int portion = PortionOfbytes(portionInPercents);
            readedPercents += portionInPercents;
            if(this.Position < PortionOfbytes(readedPercents))
                portion++;
            byte[] fileBytes = new byte[portion];
            UTF8Encoding utf8 = new UTF8Encoding();
            int count = Read(fileBytes, 0, portion);
            if(count < portion )
                return utf8.GetString(fileBytes).Substring(0, count);
            return utf8.GetString(fileBytes);
        }
    }
}
