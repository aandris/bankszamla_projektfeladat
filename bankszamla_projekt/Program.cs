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
                Console.WriteLine("BANKI UTALÁS PROGRAM");
                Console.WriteLine("1. Számlák listázása");
                Console.WriteLine("2. Befizetés");
                Console.WriteLine("3. Kifizetés");
                Console.WriteLine("4. Utalás két számla között");
                Console.WriteLine("5. Hitelkeret módosítása");
                Console.WriteLine("6. Kilépés és Naplózás");
                Console.Write("\nVálasszon egy menüpontot: ");

                string valasztas = Console.ReadLine();

                switch (valasztas)
                {
                    case "1":
                        {
                            Listazas();
                            break;
                        }
                    case "2":
                        {
                            BefizetesMenu();
                            break;
                        }
                    case "3":
                        {
                            KifizetesMenu();
                            break;
                        }
                    case "4":
                        {
                            UtalasMenu();
                            break;
                        }
                    case "5":
                        {
                            HitelkeretMenu();
                            break;
                        }
                    case "6":
                        {
                            MindenNaploMentese();
                            Console.WriteLine("A mentés sikeresen megtörtént minden számlához!");
                            kilep = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Érvénytelen választás!");
                            break;
                        }
                }
                if (!kilep)
                {
                    Console.WriteLine("\nNyomjon meg egy billentyűt a folytatáshoz...");
                    Console.ReadKey();
                }
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
        static Account SzamlaKereses(string szamlaszam)
        {
            for (int i = 0; i < szamlak.Count; i++)
            {
                if (szamlak[i].GetSzamlaszam() == szamlaszam)
                {
                    return szamlak[i];
                }
            }
            return null;
        }
        static void Listazas()
        {
            Console.WriteLine("\nAktuális számlák:");
            for (int i = 0; i < szamlak.Count; i++)
            {
                Console.WriteLine(szamlak[i].ToString());
            }
        }
        static void BefizetesMenu()
        {
            Console.Write("Adja meg a számlaszámot: ");
            Account a = SzamlaKereses(Console.ReadLine());
            if (a != null)
            {
                Console.Write("Összeg: ");
                decimal osszeg = decimal.Parse(Console.ReadLine());
                a.Deposit(osszeg);
                Console.WriteLine("Befizetés rögzítve.");
            }
            else
            {
                Console.WriteLine("Számla nem található.");
            }
        }
        static void KifizetesMenu()
        {
            Console.Write("Adja meg a számlaszámot: ");
            Account a = SzamlaKereses(Console.ReadLine());
            if (a != null)
            {
                Console.Write("Kivenni kívánt összeg: ");
                decimal osszeg = decimal.Parse(Console.ReadLine());
                if (a.Withdraw(osszeg))
                {
                    Console.WriteLine("Sikeres kifizetés.");
                }
                else
                {
                    Console.WriteLine("Hiba: Nincs elég fedezet!");
                }
            }
            else
            {
                Console.WriteLine("Számla nem található.");
            }
        }
        static void UtalasMenu()
        {
            Console.Write("Forrás számlaszám: ");
            Account forras = SzamlaKereses(Console.ReadLine());
            Console.Write("Cél számlaszám: ");
            Account cel = SzamlaKereses(Console.ReadLine());

            if (forras != null && cel != null)
            {
                Console.Write("Összeg: ");
                decimal osszeg = decimal.Parse(Console.ReadLine());
                if (forras.Utalas(cel, osszeg))
                {
                    Console.WriteLine("Sikeres utalás.");
                }
                else
                {
                    Console.WriteLine("Hiba: Nincs elég fedezet!");
                }
            }
            else
            {
                Console.WriteLine("Valamelyik számla nem létezik!");
            }
        }
        static void HitelkeretMenu()
        {
            Console.Write("Számlaszám: ");
            Account a = SzamlaKereses(Console.ReadLine());
            if (a != null)
            {
                Console.Write("Új keret: ");
                decimal uj = decimal.Parse(Console.ReadLine());
                if (a.HitelKeretModositasa(uj))
                {
                    Console.WriteLine("Sikeres módosítás.");
                }
                else
                {
                    Console.WriteLine("Hiba: Túl magas hitelkeret!");
                }
            }
            else
            {
                Console.WriteLine("Számla nem található!");
            }
        }
        static void MindenNaploMentese()
        {
            for (int i = 0; i < szamlak.Count; i++)
            {
                szamlak[i].NaploMentes();
            }
        }

    }
}