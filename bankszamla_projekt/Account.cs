using System;
using System.Collections.Generic;
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

            string sor = DateTime.Now.ToString() + ";Számlanyitás;" + Egyenleg;
            Naplo.Add(sor);
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

    }
}
