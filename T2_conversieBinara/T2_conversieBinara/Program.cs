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
            int b1, b2;
            Console.WriteLine("Introdu numarul pe care vrei sa il convertesti:");
            float n = float.Parse(Console.ReadLine());
            Console.WriteLine("Introdu baza in care se afla numarul introdus:");
            b1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Introdu baza in care vrei sa convertesti numarul:");
            b2 = int.Parse(Console.ReadLine());

            int a = Convert.ToInt32(Math.Floor(n));

            if (b1 == 10)
            {
                convDin10ParteIntreaga(a, b2);
                float b = n - a;
                if (b != 0)
                    Console.Write(".");
                while (Math.Floor(b) != b)
                {
                    b = b * b2;
                    if (b >= 1f)
                    {
                        Console.Write(b % 10);
                        b = b - 1f;

                    }



                }
            }
            


            


            Console.ReadKey();
        }

        static void convDin10ParteIntreaga(int n, int b2) //conversia pt partea intreaga a unui numar din baza 10
        {
            if (n != 0)
            {
                convDin10ParteIntreaga(n / b2, b2);
                Console.Write(n % b2);
            }
        }

        
    }
}
