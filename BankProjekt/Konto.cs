using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public class Konto
    {
        private string iban = "DE";
        private double kontoStand;
        private List<Transaktion> transaktionen;

        public Konto(string iban, double kontoStand, List<Transaktion> transaktionen)
        {
            this.iban = iban;
            this.kontoStand = kontoStand;
            this.transaktionen = transaktionen;

        }

        public Konto()
        {
        }

        public string Iban { get => iban; set => iban = value; }
        public double KontoStand 
        { 
            get => kontoStand; 
            set => kontoStand = value; 
        }
        public List<Transaktion> Transaktionen { get => transaktionen; set => transaktionen = value; }

        public Konto KontoAnlegen(Bank b)
        {
            var rand = new Random();
            int temp = rand.Next(10000000, 99999999);
            return new Konto(Iban + b.Bankleitzahl + temp, IO.ReadDouble("Kontostand : "), new List<Transaktion>());
        }

        public override string ToString() => $"Iban : {Iban} -  Kontostand : {KontoStand}";


    }
}
