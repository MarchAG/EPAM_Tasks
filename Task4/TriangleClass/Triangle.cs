using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleClass
{
    /// <summary>
    /// Сoordinates of the corners of the triangle
    /// </summary>
    public struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }
        //dist
    }
    /// <summary>
    /// Class for working with triangle
    /// </summary>
    public class Triangle
    {
        private double[] side;
        public double[] Side
        {
            
            get
            {
                return (double[])side.Clone();//clone
            }
            set
            {
                //null
                side = (double[])value.Clone();
            }//clone
        }
        /// <summary>
        /// Constructor of triangle
        /// </summary>
        /// <param name="p1">Сoordinates of the 1 corner</param>
        /// <param name="p2">Сoordinates of the 2 corner</param>
        /// <param name="p3">Сoordinates of the 3 corner</param>
        public Triangle(Point p1, Point p2, Point p3)
        {
            side = new double[3];
            side[0] = Point.Distance(p1, p2);//dist
            side[1] = Point.Distance(p1, p3);
            side[2] = Point.Distance(p2, p3);
            if (!IsExist(side[0], side[1], side[2]))
                throw new InvalidCastException(ResThrows.InvalidCastExceptionString);//spec + text
        }
        /// <summary>
        /// Constructor of triangle
        /// </summary>
        /// <param name="side">specifies the sides of the triangle</param>
        public Triangle(double[] side)
        {
            //null
            if (side == null)
                throw new ArgumentNullException(ResThrows.ArgumentNullExceptionsString);
            int len = side.Length;
             if (len != 3)
                throw new ArgumentException(ResThrows.ArgumentExceptionsString);//

             if (!IsExist(side[0], side[1], side[2]))
                 throw new InvalidCastException(ResThrows.InvalidCastExceptionString);//spec

            this.side = new double[3];
           
            for (int i = 0; i < len; i++)
                this.side[i] = side[i];
            
        }
        /// <summary>
        /// Checks for the existence of a triangle
        /// </summary>
        /// <param name="s1">1 side of triangle</param>
        /// <param name="s2">2 side of triangle</param>
        /// <param name="s3">3 side of triangle</param>
        /// <returns>existence of a triangle</returns>
        public static bool IsExist(double s1, double s2, double s3)//static s1,s2,s3
        {
            if (s3 <= 0 || s3 <= 0 || s3 <= 0)
                return false;
            return s1 < s2 + s3 && s2 < s1 + s3
                    && s3 < s2 + s1;
        }

        /// <summary>
        /// Calculate perimeter of triangle
        /// </summary>
        /// <returns>perimeter of triangle</returns>
        public double Perimeter()
        {
            double result = 0;
            int len = side.Length;
            for (int i = 0; i < len; i++)
                result += side[i];
            return result;
        }

        /// <summary>
        /// Calculate area of triangle
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - side[0]) * (p - side[1]) * (p - side[2]));
        }

        //==
        /// <summary>
        /// compares the areas of triangles
        /// </summary>
        /// <param name="triangle1"></param>
        /// <param name="triangle2"></param>
        /// <returns>is equals</returns>
        static public bool operator ==(Triangle triangle1, Triangle triangle2)
        {

            if (ReferenceEquals(triangle2, null) && ReferenceEquals(triangle1, null))
                return true;
            if (!ReferenceEquals(triangle2, null))
               return triangle2.Equals(triangle1);
            else
                return triangle1.Equals(triangle2);
        }

        static public bool operator !=(Triangle triangle1, Triangle triangle2)
        {
            return !(triangle1 == triangle2);
        }

        public override string ToString()
        {
            return this.side[0].ToString()+this.side[1].ToString()+this.side[2].ToString();
        }

        public override bool Equals(object obj)
        {
            Triangle triangle = obj as Triangle;
            if (triangle == null)
                throw new ArgumentException(ResThrows.ArgumentExceptionsString);

            return this.Area() == triangle.Area();
        }

        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }
    }
}
