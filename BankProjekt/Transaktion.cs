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
        private Transaktionsart transaktionsart;
        private string beschreibungstext;
        private double betrag;
        public Transaktion()
        {
        }
        public Transaktion(DateTime zeitstempel, Transaktionsart transaktionsart, string beschreibungstext, double betrag)
        {
            this.zeitstempel = zeitstempel;
            this.transaktionsart = transaktionsart;
            this.beschreibungstext = beschreibungstext;
            this.betrag = betrag;
        }

        public DateTime Zeitstempel { get => zeitstempel; set => zeitstempel = value; }
        public Transaktionsart Transaktionsart { get => transaktionsart; set => transaktionsart = value; }
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
            return new Transaktion(DateTime.Now, new Transaktionsart(),  Beschreibungstext, Betrag);
        }

        public Transaktion NeueTransaktionAuszahlung()
        {
            return new Transaktion(DateTime.Now, new Transaktionsart(), Beschreibungstext, Betrag);
        }


        public string ToStringEinzahlung(Konto konto) => $"{konto.Iban};{zeitstempel};{transaktionsart};{beschreibungstext};{betrag}";
        public string ToStringAuszahlung(Konto konto) => $"{konto.Iban};{zeitstempel};Auszahlung;{beschreibungstext};{betrag}";

        public void DisplayTransaktionInfo(Konto konto)
        {
            Console.WriteLine($"{konto.Iban};{zeitstempel};Einzahlung;{beschreibungstext};{betrag}");
        }

        public string ToString(Konto konto) => $"{konto.Iban};{zeitstempel};{transaktionsart};{beschreibungstext};{betrag}";


    }


    public enum Transaktionsart
    {
        Einzahlung,
        Auszahlung
    }
}
