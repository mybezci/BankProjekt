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
        public Transaktion()
        {
        }
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

        public Transaktion NeueTransaktion()
        {
            return new Transaktion(Iban, DateTime.Now, Transaktionsart, Beschreibungstext, Betrag);
        }




        public void DisplayTransaktionInfo()
        {
            Console.WriteLine(ToString());
        }

//        public string ToString(Konto konto) => $"{konto.Iban};{zeitstempel};{transaktionsart};{beschreibungstext};{betrag}";
        public override string ToString() => $"{Iban};{Zeitstempel};{Transaktionsart};{Beschreibungstext};{Betrag}";


    }


    public enum Transaktionsart
    {
        Einzahlung,
        Auszahlung
    }
}
