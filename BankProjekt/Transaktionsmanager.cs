using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public static class Transaktionsmanager
    {
        public static void AddTransaktionToList(Konto k)
        {
            if (k != null)
            {
                Transaktion transaktion = new Transaktion();
                Einzahlung(k, transaktion);
                k.Transaktionen.Add(transaktion);
                Console.WriteLine("Transaktion ist erfolgreich");
            }
            else
                Console.WriteLine("Keine Konto");

        }


        public static void Einzahlung(Konto konto, Transaktion tra)
        {
            if (konto != null)
            {
                try
                {
                    tra.Iban = konto.Iban;
                    Console.WriteLine("Kontostand : " + konto.KontoStand);
                    tra.Betrag = IO.ReadDouble("Wie viel Geld wollen sie einzahlen :");
                    if (tra.Betrag > 0 && tra.Betrag < 10000000)
                    {
                        konto.KontoStand += tra.Betrag;
                        tra.Beschreibungstext = IO.ReadString("Beschreibungstext : ");
                        tra.Zeitstempel = DateTime.Now;
                        tra.Transaktionsart = Transaktionsart.Einzahlung;
                        Console.WriteLine("Aktuell Kontostand : " + konto.KontoStand);
                    }
                    else
                        Console.WriteLine("Ungültig");
                }
                catch (Exception)
                {
                    Console.WriteLine("Einzahlen Error");
                }
            }
            else
                Console.WriteLine("Konto wurde nicht gefunden");
        }






        public static void Auszahlung(Konto konto, Transaktion tra)
        {
            if (konto != null)
            {
                try
                {
                    Console.WriteLine("Kontostand : " + konto.KontoStand);
                    double betrag = IO.ReadDouble("Wie viel Geld wollen sie auszahlen :");
                    if (betrag > 0 && betrag < konto.KontoStand)
                    {
                        konto.KontoStand -= betrag;
                        tra.Beschreibungstext = IO.ReadString("Beschreibungstext : ");
                        Console.WriteLine("Aktuell Kontostand : " + konto.KontoStand);
                        Console.WriteLine("Aktuell Kontostand : " + konto.KontoStand);
                    }
                    else if (betrag < 0)
                        Console.WriteLine("Bitte keine negative Zahl");
                    else if (betrag > konto.KontoStand)
                        Console.WriteLine("Ihr Wunsch ist grösser als Ihr Kontostand");
                    else
                        Console.WriteLine("Ungültig");
                }
                catch (Exception)
                {
                    Console.WriteLine("Einzahlen Error");
                }
            }
            else
            {
                Console.WriteLine("Kein Konten");
            }
        }

        public static void DisplayAllTransaktionen(Konto k)
        {
            Console.WriteLine("Transaktionen");
            if (!k.Equals(null))
            {
                foreach (Transaktion tr in k.Transaktionen)
                {
                    try
                    {
                        if (tr != null)
                        {
                            tr.DisplayTransaktionInfo();
                        }
                        else
                        {
                            Console.WriteLine("Keine Transaktion");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Transaktion ist null");
                    }
                }
            }
        }

        public static void DisplayAllTransaktionen(List<Kunde> kunden)
        {
            Console.WriteLine("Transaktionen");
            if (kunden != null && kunden.Count != 0)
            {
                foreach (Kunde kunde in kunden)
                {
                    foreach (Konto konto in kunde.Konten)
                    {
                        foreach (Transaktion transaktion in konto.Transaktionen)
                        {
                            try
                            {
                                if (transaktion != null)
                                {
                                    transaktion.DisplayTransaktionInfo();
                                }
                                else
                                {
                                    Console.WriteLine("Keine Transaktion");
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("Transaktion ist null");
                            }
                        }
                    }
                }
            }
        }


        public static void WriteAllLinesToFile(Konto k)
        {
            if (!k.Equals(null))
            {
                var zeilen2 = new List<string>();
                foreach (Transaktion item in k.Transaktionen)
                {
                    zeilen2.Add(item.ToString());

                }
                string pfad = @"C:\Users\Teilnehmer\source\repos\BankProjekt\BankProjekt\transaktionen.txt";
                File.WriteAllLines(pfad, zeilen2);

            }
            else
            {
                Console.WriteLine("Kein Konto");
            }
        }

        public static void ReadAllLinesFromFile()
        {
            string pfad2 = @"C:\Users\Teilnehmer\source\repos\BankProjekt\BankProjekt\transaktionen.txt";
            var allLines = File.ReadAllLines(pfad2);
            foreach (var line in allLines)
            {
                Console.WriteLine("line -> " + line.ToString());
            }
        }
    }
}
