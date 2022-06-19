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
        private DateTime zeitstempel;
        private static List<String> transaktionsarten = new List<String> {"Einzahlung", "Auszahlung" };
        private string beschreibungstext;
        private double betrag;
        public Transaktion()
        {
        }
        public Transaktion(DateTime zeitstempel, /*List<Transaktionsart> transaktionsarten,*/string transaktionart, string beschreibungstext, double betrag)
        {
            this.zeitstempel = zeitstempel;
//            this.transaktionsarten = transaktionsarten;
            this.beschreibungstext = beschreibungstext;
            this.betrag = betrag;
        }

        public DateTime Zeitstempel { get => zeitstempel; set => zeitstempel = value; }
  //      public List<Transaktionsart> Transaktionsarten { get => transaktionsarten; set => transaktionsarten = value; }
        public string Beschreibungstext { get => beschreibungstext; set => beschreibungstext = value; }
        public double Betrag { get => betrag; set => betrag = value; }

        public static string ReadLineFromFile(string pfad)
        {
            StreamReader sr = File.OpenText(pfad);
            string str = sr.ReadLine();
            sr.Close(); 
            return str;
        }
        public static void WriteTransaktionToFile(string text, string pfad)
        {
            StreamWriter sw = File.CreateText(pfad);
            sw.WriteLine(text);
            sw.Flush();
            Console.WriteLine("Transaktion is saved into file : " + sw.ToString());
            sw.Close();
        }

        public Transaktion NeueTransaktionEinzahlung()
        {
            return new Transaktion(DateTime.Now, "Einzahlung",  Beschreibungstext, Betrag);
        }

        public Transaktion NeueTransaktionAuszahlung()
        {
            return new Transaktion(DateTime.Now, "Auszahlung", Beschreibungstext, Betrag);
        }


        public string ToStringEinzahlung(Konto konto) => $"{konto.Iban};{zeitstempel};Einzahlung;{beschreibungstext};{betrag}";
        public string ToStringAuszahlung(Konto konto) => $"{konto.Iban};{zeitstempel};Auszahlung;{beschreibungstext};{betrag}";




    }
}
