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
            if (b.Kunden != null && b.Kunden.Count != 0)
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
                    }
                }

            }
        }

        public static Konto FindEinKontoDurchIban(string iban, List<Kunde> kunden)
        {

            Konto konto = null;
            if(kunden!= null && kunden.Count != 0)
            {
                foreach (Kunde kunde in kunden) { 

                    if (kunde.Konten != null && kunde.Konten.Count != 0)
                    {
                        foreach (Konto ko in kunde.Konten)
                        {
                            if (ko.Iban.Equals(iban))
                                konto = ko;
                        }
                    }
                    else
                    {
                    }
                }
            }
            else
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
                        Console.WriteLine("Kunde wurde nicht gefunden!!!");
                    }
                    else
                    {
                        Console.WriteLine("Alle Konten");
                        DisplayAllKontenVonUser(b.Kunden[ind]);
                    }
                }
                else
                {
                    Console.WriteLine("Keine Kunde");
                }
            }
            catch (Exception)
            {
            }
        }



        public static void DisplayAllKontenVonUser(Kunde k)
        {
            try
            {
                if (k.Konten != null && k.Konten.Count >= 0)
                {
                    foreach (Konto konto in k.Konten)
                    {
                        Console.WriteLine("IBAN   -> " + konto.Iban + "  Kontostand    ->" + konto.KontoStand);
                    }
                }
                else
                {
                    Console.WriteLine("Kein Konto");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FindKontenVonPrivateKunde(string input, Bank b)
        {
            try
            {
                if (b.Kunden!= null && b.Kunden.Count != 0)
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
                            Console.WriteLine("Kein Konto");
                    }
                }
                else
                {
                    Console.WriteLine("Keine Kunde");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void DisplayKontenVonPrivateKunden(Bank b, PrivateKunde pk)
        {
            if (b.Kunden != null && b.Kunden.Count != 0)
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
                        Console.WriteLine("Konten ist null");
                    }

                }
            }
        }

        private static bool DarfKontoAnlegen(Kunde kunde)
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
                }
            }
            return zustand;
        }

        public static void NeuesKontoZumKunde(Bank bank, Kunde kunde)
        {
            if (DarfKontoAnlegen(kunde))
            {
                Konto konto = new Konto();
                konto = konto.KontoAnlegen(bank);
                kunde.Konten.Add(konto);
                Console.WriteLine("Konto angelegt");
                Console.WriteLine(konto.ToString());
            }
            else
                Console.WriteLine("Falsche Eingabe");


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
                    throw new Exception("Konto wurde nicht angelegt");
            }
            else
                Console.WriteLine("Kein Konto gefunden");
        }
    }
}
