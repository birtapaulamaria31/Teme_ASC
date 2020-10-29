using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversie
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Mesaje introductorii
            Console.WriteLine("Acesta este un program care transforma un numar dintr-o baza in alta.");
            Console.WriteLine("Restrictii si precizari: bazele sunt cuprinse intre 2 si 16. Numerele sunt pozitive si pot fi cu virgula.");

            /// Input
            Console.Write("Incepe prin a introduce numarul tau: ");
            string inputNumber = Console.ReadLine();
            int bazaInitiala = 0;
            bool okay = true;
            do
            {
                try
                {
                    Console.Write("Acum baza in care este numarul tau: ");
                    bazaInitiala = int.Parse(Console.ReadLine());
                    if (bazaInitiala < 2 || bazaInitiala > 16)
                    {
                        throw new Exception();
                    }
                    okay = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Baza este inafara intervalului");
                    okay = false;
                }
            } while (!okay);
            
            


            Console.Write("Si in final, baza in care vrei sa fie convertit numarul tau: ");
            int bazaFinala = int.Parse(Console.ReadLine());

            /// Impartim sirul citit in doua siruri 
            string[] splitNumbers = inputNumber.Split('.');

            /// Convertim partea intreaga a numarului in baza 10
            int base_10 = StringToBase10(splitNumbers[0], bazaInitiala);

            ///Convertim partea fractionara a numarului in baza 10
            float base_10_fractional = FractionalStringToBase10(splitNumbers[1], bazaInitiala);

            /// Afisam partea intreaga a numarului final
            Base10ToFinal(base_10, bazaFinala);
            ///Afisam partea fractionara
            Console.Write(".");
            FractionalBase10ToFinal(base_10_fractional, bazaFinala);
            
            Console.ReadKey();
        }

        static int StringToBase10(string v, int baza)
        {
            int suma = 0;
            int putere = 1;
            // Parcurgem sirul invers
            for(int i=v.Length-1; i>=0; i--)
            {
                // Daca este o litera
                if((int)v[i]>=65 && (int)v[i]<=70 )
                {
                    suma = suma + ((int)v[i] - 55) * putere;
                    
                }
                // Daca este o cifra
                else if ((int)v[i]>=48 && (int)v[i]<=57)
                {
                    suma = suma + ((int)v[i]-48) * putere;
       
                }
                putere = putere * baza;
            }
            return suma;
        }

        static float FractionalStringToBase10(string v, int baza)
        {
            int putere = baza, i;
            float suma=0;
            //Parcurgem sirul
            for(i=0; i<v.Length; i++)
            {
                // Daca este o litera
                if ((int)v[i] >= 65 && (int)v[i] <= 70)
                {
                    suma = suma + ((int)v[i] - 55) * (1f / putere);

                }
                // Daca este o cifra
                else if ((int)v[i] >= 48 && (int)v[i] <= 57)
                {
                    suma = suma + ((int)v[i] - 48) * (1f / putere);

                }
                putere = putere * baza;
            }
            return suma;
        }

        static void Base10ToFinal(int n, int baza)
        {
            Stack<char> stiva = new Stack<char>();
            string HEX = "0123456789ABCDEF";
            while (n != 0)
            {
                int rest = n % baza;
                stiva.Push(HEX[rest]);
                n = n / baza;
            }
            while(stiva.Count()!=0)
            {
                Console.Write(stiva.Pop());
            }
        }

        static void FractionalBase10ToFinal(float n, int baza)
        {
            string HEX = "0123456789ABCDEF";
            while (Math.Floor(n)!=n)
            {
                n = n * baza;
                Console.Write(HEX[(int)n]);
                n = n - (int)n;
                //n = (n * baza - (int)(n * baza))*baza;
            }
        }


    }
}
