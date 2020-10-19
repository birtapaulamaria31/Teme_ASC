using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2_conversieBinara
{
    class Program
    {
        static void Main(string[] args)
        {
            float n = float.Parse(Console.ReadLine());
            int a = Convert.ToInt32(Math.Floor(n));

            conv(a);
            float b = n - a;
            if (b != 0)
                Console.Write(".");
            while( Math.Floor(b)!=b)
            {
                b = b * 2;
                if (b >= 1f)
                {
                    b = b - 1f;
                    Console.Write(1);
                } else
                {
                    Console.Write(0);
                }
                


            }


            
            Console.ReadKey();
        }

        static void conv(int n)
        {
            if (n != 0)
            {
                conv(n / 2);
                Console.Write(n % 2);
            }
        }
    }
}
