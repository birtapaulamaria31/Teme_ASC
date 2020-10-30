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
            bool ok = true;
            string inputNumber="";
            int puncte = 0;

                try
                {
                    Console.Write("Incepe prin a introduce numarul tau: ");
                    inputNumber = Console.ReadLine();

                    for (int i = 0; i < inputNumber.Length; i++)
                    {
                        if (inputNumber[i] == 46)
                            puncte++;
                        else if (!(inputNumber[i] >= 48 && inputNumber[i] <= 57) && !(inputNumber[i] >= 65 && inputNumber[i] <= 70))
                            throw new Exception();
                            if (puncte > 1)
                                throw new Exception();
                    }
 
                }
                catch (Exception e1)
                {
                    Console.WriteLine("!!!!!Nu ai introdus un numar scris intr-o baza intre 2 si 16!!!!!");
                    Console.WriteLine("Ruleaza programul din nou!");
                    Console.ReadKey();
                    Environment.Exit(0);
            }
      

            int bazaInitiala = 0;
            bool ok2 = true;
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
                    ok2 = true;
                }
                catch (Exception e2)
                {
                    Console.WriteLine("!!!!!Baza este in afara intervalului!!!!!");
                    ok2 = false;
                }
            } while (!ok2);

            int bazaFinala = 0;
            bool ok3 = true;
            do
            {
                try
                {
                    Console.Write("Si in final, baza in care vrei sa fie convertit numarul tau: ");
                    bazaFinala = int.Parse(Console.ReadLine());
                    if (bazaFinala < 2 || bazaFinala > 16)
                        throw new Exception();
                    ok3 = true;
                }
                catch(Exception e3)
                {
                    Console.WriteLine("!!!!!Baza este in afara intervalului!!!!!");
                    ok3 = false;
                }
            } while (!ok3);


            /// Impartim sirul citit in doua siruri 
            string[] splitNumbers = inputNumber.Split('.');

            /// Convertim partea intreaga a numarului in baza 10
            int base_10 = StringToBase10(splitNumbers[0], bazaInitiala);

            /// Afisam partea intreaga a numarului final
            Base10ToFinal(base_10, bazaFinala);

            ///Verificam daca avem parte fractionara
            if(puncte==1)
            {
                ///Convertim partea fractionara a numarului in baza 10
                float base_10_fractional = FractionalStringToBase10(splitNumbers[1], bazaInitiala);

                ///Afisam partea fractionara
                Console.Write(".");
                FractionalBase10ToFinal(base_10_fractional, bazaFinala);

            }

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
            }
        }


    }
}
