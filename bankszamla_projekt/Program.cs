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

        static List<Account> szamlak = new List<Account>();

        static void Main(string[] args)
        {

            AdatokBetoltese("szamlak.txt");

            bool kilep = false;
            while (!kilep)
            {
                Console.Clear();
                Console.WriteLine("=== EGYSZERŰ BANKI RENDSZER ===");
                Console.WriteLine("1. Számlák listázása");
                Console.WriteLine("2. Befizetés");
                Console.WriteLine("3. Kifizetés");
                Console.WriteLine("4. Utalás két számla között");
                Console.WriteLine("5. Hitelkeret módosítása");
                Console.WriteLine("6. Kilépés és Naplózás");
                Console.Write("\nVálasszon egy menüpontot: ");

                string valasztas = Console.ReadLine();


            }
        }
        static void AdatokBetoltese(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');

                string szsz = adatok[0];
                string nev = adatok[1];
                decimal egyenleg = decimal.Parse(adatok[2]);

                Account uj = new Account(szsz, nev, egyenleg, 0, egyenleg);
                szamlak.Add(uj);
            }

            sr.Close();
        }
    }
}