using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankszamla_projekt
{
    internal class Account
    {
        private string Szamlaszam;
        private string TulajdonosNeve;
        private decimal Egyenleg;
        private decimal Hitelkeret;
        private decimal KezdoEgyenleg;
        private List<string> Naplo;


        public Account(string szamlaszam, string tulajdonosneve, decimal egyenleg, decimal hitelkeret, decimal kezdoegyenleg)
        {
            Szamlaszam = szamlaszam;
            TulajdonosNeve = tulajdonosneve;
            Egyenleg = egyenleg;
            Hitelkeret = hitelkeret;
            KezdoEgyenleg = kezdoegyenleg;

            Naplo = new List<string>();

            string bejegyzes = DateTime.Now.ToString() + ";Számlanyitás;" + Egyenleg;
            Naplo.Add(bejegyzes);
        }

     
        public string GetSzamlaszam() 
        { 
            return Szamlaszam; 
        }
        public string GetTulajdonosNeve() 
        { 
            return TulajdonosNeve; 
        }
        public decimal GetEgyenleg() 
        { 
            return Egyenleg; 
        }

        public void Deposit(decimal osszeg)
        {
            if (osszeg > 0)
            {
                Egyenleg = Egyenleg + osszeg;

                string bejegyzes = DateTime.Now.ToString() + ";befizetés;" + Egyenleg;
                Naplo.Add(bejegyzes);
            }
        }
        public bool Withdraw(decimal osszeg)
        {
            if (osszeg > 0 && (Egyenleg + Hitelkeret) >= osszeg)
            {
                Egyenleg = Egyenleg - osszeg;
                string bejegyzes = DateTime.Now.ToString() + ";kifizetés;" + Egyenleg;
                Naplo.Add(bejegyzes);
                return true;
            }
            return false;
        }
        public bool Utalas(Account celSzamla, decimal osszeg)
        {

            if (Withdraw(osszeg))
            {
                celSzamla.Deposit(osszeg);
                string bejegyzes = DateTime.Now.ToString() + ";utalás;" + Egyenleg;
                Naplo.Add(bejegyzes);
                return true;
            }
            return false;
        }
        public bool HitelKeretModositasa(decimal ujHitelkeret)
        {
            if (ujHitelkeret >= 0 && ujHitelkeret <= KezdoEgyenleg * 0.2m)
            {
                Hitelkeret = ujHitelkeret;
                string bejegyzes = DateTime.Now.ToString() + ";hitelkeret módosítása;" + Egyenleg;
                Naplo.Add(bejegyzes);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Számlaszám: " + Szamlaszam + " | Név: " + TulajdonosNeve + " | Egyenleg: " + Egyenleg;
        }

        public void NaploMentes()
        {
            string fajlnev = Szamlaszam + ".txt";
            StreamWriter sw = new StreamWriter(fajlnev);

            for (int i = 0; i < Naplo.Count; i++)
            {
                sw.WriteLine(Naplo[i]);
            }
            sw.Close();
        }
    }
}
