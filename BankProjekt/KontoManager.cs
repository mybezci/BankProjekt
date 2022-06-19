using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public static class KontoManager
    {
        public static void DisplayAllKonten(Bank b)
        {
            foreach (Kunde item in b.Kunden)
            {
                try
                {
                    if (item.Konten != null && item.Konten.Count >= 0)
                    {
                        foreach (Konto konto in item.Konten)
                            Console.WriteLine("IBAN   -> " + konto.Iban + "  Kontostand    ->" + konto.KontoStand);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Konten ist null");
                }

            }
        }

        public static Konto FindEinKontoDurchIban(string iban, Kunde k)
        {
            Konto konto = null;
            try
            {
                if (k.Konten != null && k.Konten.Count != 0)
                {
                    foreach (Konto ko in k.Konten)
                    {
                        if (ko.Iban.Equals(iban))
                            konto = ko;
                    }
                }
                else
                    throw new Exception("Kein Ergebnis   ---->");
            }
            catch (Exception ex)
            {
            }
            return konto;
        }

        public static void FindAlleKontenEinerKundeDurchKundennummer(int kundennummer, Bank b)
        {

            try
            {
                if (b.Kunden != null && b.Kunden.Count != 0)
                {
                    int ind = b.Kunden.FindIndex(x => x.Kundennummer.Equals(kundennummer));
                    if (ind < 0 || ind > b.Kunden.Count - 1)
                    {
                        Console.WriteLine("Kunde kann nicht gefunden werden!!!");
                    }
                    else
                    {
                        Console.WriteLine("Alle Konten");
                        b.Kunden[ind].DisplayAllKontenVonUser();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("");
            }
        }


        public static void FindKontenVonPrivateKunde(string input, Bank b)
        {
            try
            {
                foreach (PrivateKunde kunde in b.Kunden)
                {
                    if (kunde.Konten != null && kunde.Konten.Count >= 0)
                    {
                        if (input.Equals(kunde.Kundennummer))
                        {
                            int ind = b.Kunden.FindIndex(x => x.Konten.Equals(input));
                            Console.WriteLine(b.Kunden[ind].ToString());
                        }
                    }
                    else
                        Console.WriteLine("Konten ist nulllll");
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }



        public static void DisplayKontenVonPrivateKunden(Bank b, PrivateKunde pk)
        {
            foreach (PrivateKunde item in b.Kunden)
            {
                try
                {
                    if (item.Konten != null && item.Konten.Count >= 0)
                    {
                        foreach (Konto konto in item.Konten)
                            Console.WriteLine(pk.Nachname + "-" + "IBAN   -> " + konto.Iban + "  Kontostand    ->" + konto.KontoStand);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Konten ist null");
                }

            }
        }

        public static bool DarfKontoAnlegen(Kunde kunde)
        {
            bool zustand = false;
            if (kunde != null)
            {
                try
                {
                    if (kunde.Konten == null)
                    {
                        kunde.Konten = new List<Konto>();
                    }
                    int kontoanzahl = kunde.Konten.Count;
                    Console.WriteLine("Kunde hat " + kontoanzahl + " Konten");

                    if (kontoanzahl >= 0 && kontoanzahl <= 10)
                    {
                        zustand = true;
                    }
                    else if (kontoanzahl > 10)
                    {
                        Console.WriteLine("man darf max 10 Konten");
                        zustand = false;
                    }
                    else
                    {
                        Console.WriteLine("Kein Konto");
                        zustand = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return zustand;
        }

        public static void NeuesKontoZumKunde(Bank bank, Kunde kunde)
        {
            try
            {
                if (bank.Kunden != null && bank.Kunden.Count != 0)
                {
                        if (kunde.Konten == null)
                            kunde.Konten = new List<Konto>();
                }
                else
                    throw new Exception("exxxxx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void AddKontoZumKunde(Bank bank, Kunde kunde) { 

            if (kunde.Konten != null)
            {
                int kontoanzahl = kunde.Konten.Count;
                Console.WriteLine("Kunde hat " + kontoanzahl + " Konten");

                if (kontoanzahl >= 0 && kontoanzahl <= 10)
                {
                    Konto konto = null;
                    konto = konto.KontoAnlegen(bank);
                    kunde.Konten.Add(konto);
                    Console.WriteLine("Konto angelegt");
                }
                else if (kontoanzahl > 10)
                    Console.WriteLine("man darf max 10 Konten");
                else
                    throw new Exception("Konto Exception");
            }
            else
                throw new Exception("Nulll");
        }


        public static void Einzahlung(Konto konto, Transaktion tra)
        {
            if (konto != null)
            {
                try
                {
                    Console.WriteLine("Kontostand : " + konto.KontoStand);
                    tra.Betrag = IO.ReadDouble("Wie viel Geld wollen sie einzahlen :");
                    if (tra.Betrag > 0 && tra.Betrag < 10000000)
                    {
                        konto.KontoStand += tra.Betrag;
                        tra.Beschreibungstext = IO.ReadString("Beschreibungstext : ");
                        Console.WriteLine("Aktuell Kontostand : " + konto.KontoStand);
                    }
                    else
                        Console.WriteLine("Ungültig");
                }
                catch (Exception ex)
                { 
                    Console.WriteLine("Einzahlen Error");
                }
            }
            else
                Console.WriteLine("Kein Konten");
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
                catch (Exception ex)
                {
                    Console.WriteLine("Einzahlen Error");
                }
            }
            else
            {
                Console.WriteLine("Kein Konten");
            }
        }


    }
}
