using System;
using System.Collections.Generic;
using Util;

namespace BankProjekt
{
    class Program
    {
        static void Main(string[] args)
        {

            Bank b = new Bank("mybank", "020202", 2000, new Adresse("mystrasse1", "11111", "Mystadt"), new List<Kunde>());





            bool showMenu = true;
            do
            {
                //    showMenu = MainMenu(b);
                Console.Clear();
                Console.WriteLine("Wähle eine Option:");
                Console.WriteLine("(01) Privatkunde anlegen");
                Console.WriteLine("(02) Firmenkunde anlegen");
                Console.WriteLine("(03) Konto anlegen und Kundennummer zuordnen");
                Console.WriteLine("(04) Kunde mit Konten anzeigen (Auswahl durch Kundennummer)");
                Console.WriteLine("(05) Kunde mit Konten anzeigen (Auswahl durch Namen)");
                Console.WriteLine("(06) Konto anzeigen (Auswahl durch IBAN)");
                Console.WriteLine("(07) Alle Kunden unsortiert anzeigen");
                Console.WriteLine("(08) Alle Kunden sortiert nach aufsteigender Kundenummer anzeigen");
                Console.WriteLine("(09) Alle Konten unsortiert anzeigen");
                Console.WriteLine("(10) Beenden");

                Console.Write("\r\n Option auswählen ");

                switch (Console.ReadLine())
                {
                    case "1":
                        PrivateKunde pk = PrivateKunde.NeuePrivateKunde(b);
                        pk.displayInfo(pk);
                        b.Kunden.Add(pk);
                        IO.ReadString("weiter");
                        break;

                    case "2":
                        FirmenKunde fk = FirmenKunde.NeueFirmenKunde(b);
                        fk.displayInfo(fk);
                        b.Kunden.Add(fk);
                        IO.ReadString("weiter");
                        break;

                    case "3":
                        int inputKundennummer = IO.ReadInteger("Um neues Konto anzulegen, bitte geben Sie Ihre Kundennummer : ");

                        if (b.Kunden != null)
                        {
                            int ind = b.Kunden.FindIndex(x => x.Kundennummer.Equals(inputKundennummer));
                            Console.WriteLine("Index ->" + ind);

                            if (ind < 0 || ind > b.Kunden.Count - 1)
                            {
                                Console.WriteLine("Kunde kann nicht gefunden werden!!!");
                            }
                            else
                            {
                                Console.WriteLine("b.Kunden[ind]   ---->  " + b.Kunden[ind]);
                                Konto konto = new Konto();
                                if (b.Kunden[ind].Konten == null)
                                {
                                    b.Kunden[ind].Konten = new List<Konto>();
                                }
                                KontoManager.NeuesKontoZumKunde(b, b.Kunden[ind], konto);
                            }
                            Console.WriteLine("---");
                            Console.WriteLine("74    b.Kunden[ind].DisplayAllKonten();     UNTEN     --->");
                        }
                        else
                        {
                            throw new Exception("exxxxx");
                        }
                        IO.ReadString("weiter");
                        break;

                    case "4":

                        int inputKn = IO.ReadInteger("Um Konto zu sehen, bitte geben Sie Ihre Kundennummer : ");

                        if (b.Kunden != null)
                        {
                            int ind = b.Kunden.FindIndex(x => x.Kundennummer.Equals(inputKn));
                            Console.WriteLine("Index ->" + ind);

                            if (ind < 0 || ind > b.Kunden.Count - 1)
                            {
                                Console.WriteLine("Kunde kann nicht gefunden werden!!!");
                            }
                            else
                            {
                                Console.WriteLine("b.Kunden[ind]   ---->  " + b.Kunden[ind]);
                                Console.WriteLine("98    b.Kunden[ind].DisplayAllKonten();     UNTEN     --->");
                                b.Kunden[ind].DisplayAllKontenVonUser();

                            }
                        }
                        else
                        {
                            throw new Exception("exxxxx");
                        }
                        IO.ReadString("weiter");
                        break;

                    case "5":
                        string input = IO.ReadString("Um Konto zu sehen, bitte geben Sie Ihr Name : ");

                        KontoManager.FindKontenVonPrivateKunde(input, b);

                        IO.ReadString("weiter");
                        break;


                    case "6":
                        Console.WriteLine("Kundennamen");
                        //DisplayAllKundenNamen(b);
                        break;

                    case "7":
                        Console.WriteLine("KUNDEN");
                        b.DisplayAllKunden();
                        IO.ReadString("weiter");
                        break;
                    case "8":
                        break;
                    case "9":
                        KontoManager.DisplayAllKonten(b);
                        IO.ReadString("weiter");
                        break;

                    case "10":
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
    class IO
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
