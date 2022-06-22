using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public class Transaktion
    {
        private string iban;
        private DateTime zeitstempel;
        private Transaktionsart transaktionsart;
        private string beschreibungstext;
        private double betrag;

        public Transaktion(string iban, DateTime zeitstempel, Transaktionsart transaktionsart, string beschreibungstext, double betrag)
        {
            this.iban = iban;
            this.zeitstempel = zeitstempel;
            this.transaktionsart = transaktionsart;
            this.beschreibungstext = beschreibungstext;
            this.betrag = betrag;
        }

        public string Iban { get => iban; set => iban = value; }
        public DateTime Zeitstempel { get => zeitstempel; set => zeitstempel = value; }
        public Transaktionsart Transaktionsart { get => transaktionsart; set => transaktionsart = value; }
        public string Beschreibungstext { get => beschreibungstext; set => beschreibungstext = value; }
        public double Betrag { get => betrag; set => betrag = value; }

        public Transaktion NeueTransaktion()
        {
            return new Transaktion(Iban, DateTime.Now, Transaktionsart, Beschreibungstext, Betrag);
        }

        public void DisplayTransaktionInfo()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString() => $"{Iban};{Zeitstempel};{Transaktionsart};{Beschreibungstext};{Betrag}";

    }


    public enum Transaktionsart
    {
        Einzahlung,
        Auszahlung
    }
}
