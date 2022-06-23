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
        public static void AddTransaktionToList(Konto k, Transaktion transaktion)
        {
            if (k != null && k.Transaktionen != null)
            {
                k.Transaktionen.Add(transaktion);
                Console.WriteLine("Aktuell Kontostand : " + k.KontoStand);
                Console.WriteLine("Transaktion ist erfolgreich");
            }
            else
                Console.WriteLine("Transaktion ist nicht erfolgreich");

        }




        public static Transaktion Einzahlung(Konto konto)
        {
            if (konto != null)
            {
                try
                {
                    Console.WriteLine("Kontostand : " + konto.KontoStand);
                    double betrag = IO.ReadDouble("Wie viel Geld wollen sie einzahlen : ");
                    
                    if (betrag > 0 && betrag < 10000000)
                    {
                        konto.KontoStand += betrag;
                        return new Transaktion(konto.Iban,DateTime.Now,Transaktionsart.Einzahlung,IO.ReadString("Beschreibungstext : "),betrag);
                    }
                    else
                        Console.WriteLine("Ungültige Eingabe");
                }
                catch (Exception)
                {
                }
            }
            

            return null;
        }

        public static Transaktion Auszahlung(Konto konto)
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
                        return new Transaktion(konto.Iban, DateTime.Now, Transaktionsart.Auszahlung, IO.ReadString("Beschreibungstext : "), betrag);
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
                }
            }
            else
                Console.WriteLine("Konto wurde nicht gefunden");
            return null;
        }


        public static void DisplayAllTransaktionen(Konto k)
        {
            Console.WriteLine("Transaktionen");
            if (k != null && k.Transaktionen != null)
            {
                foreach (Transaktion tr in k.Transaktionen)
                {
                    try
                    {
                        if (tr != null)
                        {
                            tr.DisplayTransaktionInfo();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Transaktion ist null");
                    }
                }
            }
            else
            {
                Console.WriteLine("Keine Transaktion");
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
            else
            {
                Console.WriteLine("Kein Ergebnis");
            }
        }


        public static void WriteAllLinesToFile(Konto k)
        {
            if (k !=null)
            {
                var zeilen = new List<string>();
                if (k.Transaktionen != null && k.Transaktionen.Count != 0)
                {

                    foreach (Transaktion item in k.Transaktionen)
                    {
                        zeilen.Add(item.ToString());
                    }
                    string pfad = @"C:\Users\Teilnehmer\source\repos\BankProjekt\BankProjekt\transaktionen.csv";
                    File.WriteAllLines(pfad, zeilen);
                    var message =(File.Exists(pfad)) ? "Datei gibt es bereits im System" : "Datei existiert noch nicht";
                    Console.WriteLine(message);
                    
                }
                else
                {
                    Console.WriteLine("Keine Transaktionen");
                }

            }
            else
            {
                Console.WriteLine("Kein Konto");
            }
        }

        public static void ReadAllLinesFromFile()
        {
            string pfad2 = @"C:\Users\Teilnehmer\source\repos\BankProjekt\BankProjekt\transaktionen.csv";
            if (File.Exists(pfad2))
            {
                var allLines = File.ReadAllLines(pfad2);
                foreach (var line in allLines)
                {
                    Console.WriteLine("line -> " + line.ToString());
                }
            }
            else
            {
                Console.WriteLine("Es gibt kein Datei");
            }
        }

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
    }
}
