using System;
using System.Collections.Generic;
using Util;

namespace BankProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu = "Wähle eine Option:\n" +
                "(01) Privatkunde anlegen\n" +
                "(02) Firmenkunde anlegen\n" +
                "(03) Konto anlegen und Kundennummer zuordnen\n" +
                "(04) Kunde mit Konten anzeigen (Auswahl durch Kundennummer)\n" +
                "(05) Kunde mit Konten anzeigen (Auswahl durch Namen)\n" +
                "(06) Konto anzeigen (Auswahl durch IBAN)\n" +
                "(07) Alle Kunden unsortiert anzeigen\n" +
                "(08) Alle Kunden sortiert nach aufsteigender Kundenummer anzeigen\n" +
                "(09) Alle Konten unsortiert anzeigen\n" +
                "(10) Geld auf Konto einzahlen\n" +
                "(11) Geld vom Konto abheben\n" +
                "(12) Transaktionsliste absteigend sortiert nach Zeitstempel anzeigen\n" +
                "(13) Transaktionsliste aufsteigend sortiert nach Zeitstempel speichern\n" +
                "(14) Transaktionsliste einlesen\n" +
                "(15) Beenden\n";

            Bank b = new Bank("mybank", "020202", 2000, new Adresse("mystrasse1", "11111", "Mystadt"), new List<Kunde>());

            bool showMenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.Write("\r\n Bitte eine Option auswählen ");

                switch (Console.ReadLine())
                {
                    case "1":
                        PrivateKunde pk = PrivateKunde.NeuePrivateKunde(b);
                        pk.displayInfo();
                        b.Kunden.Add(pk);
                        IO.ReadString("weiter");
                        break;

                    case "2":
                        FirmenKunde fk = FirmenKunde.NeueFirmenKunde(b);
                        fk.displayInfo();
                        b.Kunden.Add(fk);
                        IO.ReadString("weiter");
                        break;

                    case "3":
                        int inputKundennummer = IO.ReadInteger("Um neues Konto anzulegen, bitte geben Sie Ihre Kundennummer : ");
                        Kunde suchteKunde = KundeManager.FindKundeDurchKundennummer(inputKundennummer, b);

                        if (KontoManager.DarfKontoAnlegen(suchteKunde))
                        {
                            Konto konto = new Konto();
                            konto = konto.KontoAnlegen(b);
                            suchteKunde.Konten.Add(konto);

                            Console.WriteLine("Konto angelegt");
                        }

                        IO.ReadString("weiter");
                        break;

                    case "4":
                        int inputKn = IO.ReadInteger("Um Konto zu sehen, bitte geben Sie Ihre Kundennummer : ");
                        KontoManager.FindAlleKontenEinerKundeDurchKundennummer(inputKn, b);

                        IO.ReadString("weiter");
                        break;

                    case "5":
                        Console.WriteLine("Wählen Sie eine Option:\n" +
                            "(1) Privatkunde" +
                            "(2) Firmenkunde");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                string input = IO.ReadString("Bitte geben Sie Ihr Nachname : ");
                                KundeManager.DisplayPrivateKunde(input, b);
                                break;

                            case "2":
                                input = IO.ReadString("Bitte geben Sie Ihr Firmenname : ");
                                KundeManager.DisplayFirmenKunde(input, b);
                                break;

                            default:
                                Console.WriteLine("Falsche Eingabe");
                                break;
                        }
                        IO.ReadString("weiter");
                        break;


                    case "6":
                        string inputIban = IO.ReadString("Um Konto zu sehen, bitte geben Sie Ihre Ibannummer : ");
                        KundeManager.DisplayKundeDurchIban(inputIban, b);

                        IO.ReadString("weiter");
                        break;

                    case "7":
                        Console.WriteLine("ALLE KUNDEN");
                        b.DisplayAllKunden();
                        IO.ReadString("weiter");
                        break;

                    case "8":
                        Console.WriteLine("ALLE KUNDEN");
                        b.DisplayAllKundenNachKundennummer();
                        IO.ReadString("weiter");
                        break;

                    case "9":
                        KontoManager.DisplayAllKonten(b);
                        IO.ReadString("weiter");
                        break;


                    /*
                     *          "(10) Geld auf Konto einzahlen" +
                                "(11) Geld vom Konto abheben" +
                                "(12) Transaktionsliste absteigend sortiert nach Zeitstempel anzeigen" +
                                "(13) Transaktionsliste aufsteigend sortiert nach Zeitstempel speichern" +
                                "(14) Transaktionsliste einlesen"
                     * */


                    case "10":
                        string iban = IO.ReadString("Für die Einzahlung geben Sie ein IBAN : ");
                        foreach (Kunde kunde in b.Kunden)
                        {
                            Konto konto = KontoManager.FindEinKontoDurchIban(iban, kunde);
                            Transaktion transaktion = new Transaktion();
                            transaktion = transaktion.NeueTransaktionEinzahlung();
                            KontoManager.Einzahlung(konto,transaktion);
/*                            if (konto.Transaktionen.Equals(null))
                            {
                                konto.Transaktionen = new List<Transaktion>();
                            }*/
//                            konto.Transaktionen.Add(transaktion);
                            string text = transaktion.ToStringEinzahlung(konto);
                            string pfad = @"C:\Users\Teilnehmer\source\repos\BankProjekt\BankProjekt\transaktionen.txt";
                            Transaktion.WriteTransaktionToFile(text,pfad);
                        }
                                          
                        IO.ReadString("weiter");
                        break;

                    case "11":
                        iban = IO.ReadString("Für die Auszahlung geben Sie ein IBAN : ");
                        foreach (Kunde kunde in b.Kunden)
                        {
                            Konto konto = KontoManager.FindEinKontoDurchIban(iban, kunde);
                            Transaktion transaktion = new Transaktion();
                            transaktion = transaktion.NeueTransaktionAuszahlung();
                            KontoManager.Auszahlung(konto, transaktion);
                            /*                            if (konto.Transaktionen.Equals(null))
                                                        {
                                                            konto.Transaktionen = new List<Transaktion>();
                                                        }*/
                            //                            konto.Transaktionen.Add(transaktion);
                            string text = transaktion.ToStringAuszahlung(konto);
                            string pfad = @"C:\Users\Teilnehmer\source\repos\BankProjekt\BankProjekt\transaktionen.txt";
                            Transaktion.WriteTransaktionToFile(text, pfad);
                        }
                        IO.ReadString("weiter");
                        break;

                    case "12":
                        KontoManager.DisplayAllKonten(b);
                        IO.ReadString("weiter");
                        break;

                    case "13":
                 
                        IO.ReadString("weiter");
                        break;

                    case "14":
                        Console.WriteLine(Transaktion.ReadLineFromFile(@"C:\Users\Teilnehmer\source\repos\BankProjekt\BankProjekt\transaktionen.txt"));
                        IO.ReadString("weiter");
                        break;

                    case "15":
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Bitte eine ");
                        break;
                }
            }
            while (showMenu);

        }
    
    }

}




namespace Util
{
    public class IO
    {
        public static String ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        public static int ReadInteger(string prompt)
        {
            int i;
            Int32.TryParse(ReadString(prompt), out i);
            return i;
        }
        public static double ReadDouble(string prompt)
        {
            double d;
            Double.TryParse(ReadString(prompt), out d);
            return d;
        }
        public static DateTime ReadDate(string prompt)
        {
            DateTime d;
            DateTime.TryParse(ReadString(prompt), out d);
            return d;
        }

    }
}
