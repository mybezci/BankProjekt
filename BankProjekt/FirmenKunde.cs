using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public class FirmenKunde:Kunde
    {
        private string firmenname;
        private Ansprechpartner ansprechpartner;

        public FirmenKunde(int kundennummer, string firmenname, Ansprechpartner ansprechpartner, string telefonnummer, string email, Adresse adress) :
            base(kundennummer, telefonnummer, email, adress)
        {
            this.firmenname = firmenname.Trim().ToUpper();
            this.ansprechpartner = ansprechpartner;
        }

        public string Firmenname { get => firmenname; set => firmenname = value; }

        public static FirmenKunde NeueFirmenKunde(Bank b)
        {
            int kn = b.Kunden.Count;
            return new FirmenKunde(
                kn + 1,
                IO.ReadString("Firmaname: "),
                new Ansprechpartner(IO.ReadString("Ansp. Vorname: "), IO.ReadString("Ansp. Nachname: "), IO.ReadString("Ansp. Telnr: ")),
                IO.ReadString("Telefonnr: "),
                IO.ReadString("Email: "),
                new Adresse(IO.ReadString("Strasse: "), IO.ReadString("Plz: "), IO.ReadString("Ort: "))
                );
        }

        public void displayInfo()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString() => $"Firmenkunden: Kundennummer : {Kundennummer} - Name : {Firmenname} ;" +
            $"Ansprechpartner : {ansprechpartner.Nachname} {ansprechpartner.Vorname} {ansprechpartner.Telefonnummer}   " +
            $"Email : {Email} - Telefon: {Telefonnummer} Adress {Adress.StrasseMitHausnummer} {Adress.Plz} {Adress.Ort}";


    }
}
