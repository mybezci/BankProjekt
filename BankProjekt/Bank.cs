using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public class Bank
    {
        private string name;
        private string bic;
        private int bankleitzahl;
        private Adresse adress;
        private List<Kunde> kunden;
        private List<Transaktion> alleTransaktionen;


        public Bank(string name, string bic, int bankleitzahl, Adresse adress, List<Kunde> kunden)
        {
            this.name = name.Trim().ToUpper();
            this.bic = bic.Trim().ToUpper();
            this.bankleitzahl = bankleitzahl;
            this.adress = adress;
            this.kunden = kunden;
        }

        public Bank(string name, string bic, Adresse adress)
        {
            this.name = name;
            this.bic = bic;
            this.adress = adress;
        }

        public string Name { get => name; set => name = value; }
        public string Bic { get => bic; set => bic = value; }
        public int Bankleitzahl
        {
            get => bankleitzahl;
            set => bankleitzahl = (bankleitzahl < 1000 || bankleitzahl > 9999) ? 1000 : value;
        }

        public Adresse Adresse { get => adress; set => adress = value; }
        public List<Kunde> Kunden { get => kunden; set => kunden = value; }
        public List<Transaktion> AlleTransaktionen { get => alleTransaktionen; set => alleTransaktionen = value; }

        public void DisplayAllKunden()
        {
            foreach (Kunde kunde in Kunden)
            {
                Console.WriteLine(kunde);
            }
        }


        public void DisplayAllKundenNachKundennummer()
        {
            Kunden.Sort();
            foreach (Kunde kunde in Kunden)
            {
                Console.WriteLine(kunde);
            }
        }

        public string IbanErstellen(Konto k)
        {
            var rand = new Random();
            return k.Iban + Bic + rand;
        }

    }
}
