using System;

namespace VendingMachine
{
    class Program
    {
        public static int centi = 0;
        public static int[] valori = new int[] { 5, 10, 25 };
        static void ShowMessage()
        {

            if (centi >= 20)
            {
                Console.Clear();
                Console.WriteLine($"\nIn aparat se afla {centi} centi");
                Console.WriteLine("Ai obtinut un pachet de chipsuri, felicitari!");
                if (centi > 20)
                {
                    if(centi-20==valori[0])
                        Console.WriteLine($"Poftim si 1 Nickel ({centi - 20} centi) inapoi, este restul tau.");
                    else if(centi - 20 == valori[1])
                        Console.WriteLine($"Poftim si 1 Dime ({centi - 20} centi) inapoi, este restul tau.");
                    else if(centi - 20 == 15)
                        Console.WriteLine($"Poftim si 1 Dime ({valori[1]} centi) si 1 Nickel ({valori[0]} centi) inapoi, este restul tau.");
                    else if(centi-20 == 20)
                        Console.WriteLine($"Poftim si 1 Dime ({valori[1]} centi) si 2 Nickel (2*{valori[0]} centi) inapoi, este restul tau.");
                }
                Console.ReadKey();
                centi = 0;
            }

            Console.Clear();

            Console.WriteLine("Buna ziua, bine ai venit la automatul de vanzari!");
            Console.WriteLine("Momentan avem doar un produs (un pachet de chipsuri) si costa 20 centi");
            
            Console.WriteLine($"\nIn aparat se afla {centi} centi");

            Console.WriteLine("Alegeti tipul de moneda pe care doriti sa o introduceti:");
            Console.WriteLine("1. Nickel (5 centi)");
            Console.WriteLine("2. Dime (10 centi)");
            Console.WriteLine("3. Quarter (25 centi)");

            Console.Write("Optiunea ta: ");
            int optiune = int.Parse(Console.ReadLine());

            centi += valori[optiune - 1];
              
            ShowMessage();

        }

        static void Main(string[] args)
        {
            ShowMessage();

            Console.ReadKey();
        }
    }
}
