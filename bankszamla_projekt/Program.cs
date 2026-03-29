using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace bankszamla_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool kilep = false;
            while (!kilep)
            {
                Console.Clear();
                Console.WriteLine("=== EGYSZERŰ BANKI RENDSZER ===");
                Console.WriteLine("1. Számlák listázása");
                Console.WriteLine("2. Befizetés");
                Console.WriteLine("3. Kifizetés");
                Console.WriteLine("4. Utalás");
                Console.WriteLine("5. Hitelkeret módosítása");
                Console.WriteLine("6. Kilépés és Naplózás");
                Console.Write("\nVálasszon egy menüpontot: ");

                string valasztas = Console.ReadLine();


            }
        }      
    }
}
