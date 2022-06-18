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

        public Konto(Kunde kunde, string iban, double kontoStand)
        {

            this.iban = iban;
            this.kontoStand = kontoStand;
        }

        public Konto()
        {
        }

        public string Iban { get => iban; set => iban = value; }
        public double KontoStand { get => kontoStand; set => kontoStand = value; }


        public Konto KontoAnlegen(Bank b, Kunde kunde)
        {
            var rand = new Random();
            int temp = rand.Next(10000000, 99999999);
            return new Konto(kunde, Iban + b.Bankleitzahl + temp, IO.ReadDouble("Kontostand : "));
        }

        public override string ToString() => $"Iban : {Iban} -  Kontostand : {KontoStand}";
    }
}
