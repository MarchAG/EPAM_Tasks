using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NODClassLibrary
{
    public class NOD
    {
        static void Swap(ref int a, ref int b)
        {
                a ^= b;
                b ^= a;
                a ^= b;
        }

        static public int Euclidean(int a, int b)
        {
            while(a != 0)
            {
                if (a < b)
                    Swap(ref a, ref b);
                a %= b;
            }
            return b;
        }

        static public int Euclidean(params int[] array)
        {
            //
            int len = array.Length;
            if(len == 1)
                return array[0];
            int result = Euclidean(array[0], array[1]);
            for (int i = 2; i < len; i++)
                result = Euclidean(result, array[i]);
            return result;
        }

        static public int Euclidean(int a, int b, out double runtime)
        {
            Stopwatch stop = new Stopwatch();
            int result = 0;
            stop.Start();
            result = Euclidean(a, b);
            stop.Stop();
            runtime = stop.Elapsed.TotalMilliseconds;
            return result;
        }

        static public int Stain(int a, int b)
        {
            if(a < 0)
                a = -a;
            if (b < 0)
                b = -b;
            if (a == 0 && b != 0)
                return b;
            else if (a != 0 && b == 0)
                return a;
            else if (a % 2 == 0 && b % 2 == 0)
                return 2 * Stain(a / 2, b / 2);
            else if (a % 2 == 0 && b % 2 == 1)
                return Stain(a / 2, b);
            else if (b % 2 == 0 && a % 2 == 1)
                return Stain(a, b / 2);
            else
                if (a > b)
                    return Stain(a - b, b);
                else
                    if (a < b)
                        return Stain(b - a, a);
            return a;
        }

        static public int Stain(int a, int b, out double runtime)
        {
            Stopwatch stop = new Stopwatch();
            int result = 0;
            stop.Start();
            result = Stain(a, b);
            stop.Stop();
            runtime = stop.Elapsed.TotalMilliseconds;
            return result;
        }
    }
}
