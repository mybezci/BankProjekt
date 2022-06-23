using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
                        KontoManager.NeuesKontoZumKunde(b,suchteKunde);

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
                        KundeManager.DisplayAllKunden(b);
                        IO.ReadString("weiter");
                        break;

                    case "8":
                        Console.WriteLine("ALLE KUNDEN");
                        KundeManager.DisplayAllKundenNachKundennummer(b);
                        IO.ReadString("weiter");
                        break;

                    case "9":
                        KontoManager.DisplayAllKonten(b);
                        IO.ReadString("weiter");
                        break;

                    case "10":
                        string iban = IO.ReadString("Für die Einzahlung geben Sie ein IBAN : ");
                        Konto k = KontoManager.FindEinKontoDurchIban(iban, b.Kunden);
                        Transaktionsmanager.AddTransaktionToList(k, Transaktionsmanager.Einzahlung(k));

                        IO.ReadString("weiter");
                        break;

                    case "11":
                        string iban2 = IO.ReadString("Für die Auszahlung geben Sie ein IBAN : ");
                        Konto k2 = KontoManager.FindEinKontoDurchIban(iban2, b.Kunden);
                        Transaktionsmanager.AddTransaktionToList(k2,Transaktionsmanager.Auszahlung(k2));
                         IO.ReadString("weiter");
                        break;

                    case "12":
                        string iban4 = IO.ReadString("Für die Transaktionslist, geben Sie ein IBAN : ");
                        Transaktionsmanager.DisplayAllTransaktionen(KontoManager.FindEinKontoDurchIban(iban4, b.Kunden));
                        
                        IO.ReadString("weiter");
                        break;


                    case "13":
                        string iban5 = IO.ReadString("Um die Transaktionen zu speichern, geben Sie ein IBAN : ");
                        Konto kon = (KontoManager.FindEinKontoDurchIban(iban5, b.Kunden));
                        Transaktionsmanager.WriteAllLinesToFile(kon);

                        IO.ReadString("weiter");
                        break;

                    case "14":
                        Transaktionsmanager.ReadAllLinesFromFile();

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


    public class PrueftInput
    {
        public static string forText = @"^[a-zA-Z]*$";
        public static string messageForText = "Nur Buchstaben";

        public static string forNumber = @"^(0|\+?[1-9]\d*)$";
        public static string messageForNumber = "Nur Nummer";

        public static string forDouble = @"/\(?[\d.]+\)?/";
        public static string messageForDouble = "Nur Nummer";

        public static string forEmail = @"^\S+@\S+\.\S+$";
        public static string messageForEmail = "Ungültiges Email";


        public static string forTelefon = @"^\d{5,14}$";
        public static string messageForTelefon = "Ungültige Telefonnummer";


        public static string forStrasse = @"^[a-zA-Z09]*$";
        public static string messageForStrasse = "Nur Buchstaben und Nummer";


        public static string forPlz = @"^[0-9]{5}(?:-[0-9]{4})?$";
        public static string messageForPlz = "Ungültiges PLZ";


        public static  string forDate = @"(0[1 - 9] |[12][0 - 9] | 3[01])[.](0[1 - 9] | 1[012])[.]\d{4} ";
        public static string messageForDate = "Ungültige Datum Bitte tt.mm.yyyy";


        public static bool PrueftRegex<T>(T input, string regexBefehle, string message)
        {
            string text = Convert.ToString(input);
            do
            {
               //text = Convert.ToString(input);

                    if (Regex.IsMatch(text, regexBefehle))
                    {                   
                        return true;
                    }
                    else
                    {
                       Console.WriteLine(message);
                        return false;
                    }


            } while (!Regex.IsMatch(text,regexBefehle));
            
        }



    }
}
