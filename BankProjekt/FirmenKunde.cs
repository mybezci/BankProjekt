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
            string name;
            do
            {
                name = IO.ReadString("Firmenname: ");
            }
            while (!PrueftInput.PrueftRegex(name, PrueftInput.forText, PrueftInput.messageForText));

            string anVorname;
            do
            {
                anVorname = IO.ReadString("Ansprechpartner Vorname: ");
            }
            while (!PrueftInput.PrueftRegex(anVorname, PrueftInput.forText, PrueftInput.messageForText));

            string anNachname;
            do
            {
                anNachname = IO.ReadString("Ansprechpartner Nachname: ");
            }
            while (!PrueftInput.PrueftRegex(anNachname, PrueftInput.forText, PrueftInput.messageForText));

            string ansTelefon;
            do
            {
                ansTelefon = IO.ReadString("Ansprechpartner Telefon : ");
            }
            while (!PrueftInput.PrueftRegex(ansTelefon, PrueftInput.forTelefon, PrueftInput.messageForTelefon));

            string telefon;
            do
            {
                telefon = IO.ReadString("Telefon : ");
            }
            while (!PrueftInput.PrueftRegex(telefon, PrueftInput.forTelefon, PrueftInput.messageForTelefon));

            string email;
            do
            {
                email = IO.ReadString("Email : ");
            }
            while (!PrueftInput.PrueftRegex(email, PrueftInput.forEmail, PrueftInput.messageForEmail));

            string strasse;
            do
            {
                strasse = IO.ReadString("Strasse: ");
            }
            while (!PrueftInput.PrueftRegex(strasse, PrueftInput.forStrasse, PrueftInput.messageForStrasse));

            string plz;
            do
            {
                plz = IO.ReadString("PLZ : ");
            }
            while (!PrueftInput.PrueftRegex(plz, PrueftInput.forPlz, PrueftInput.messageForPlz));

            string ort;
            do
            {
                ort = IO.ReadString("Ort : ");
            }
            while (!PrueftInput.PrueftRegex(ort, PrueftInput.forText, PrueftInput.messageForText));

            int kn = b.Kunden.Count;
            return new FirmenKunde(
                kn + 1,
                name,
                new Ansprechpartner(anVorname, anNachname, ansTelefon),
                telefon, 
                email,
                new Adresse(strasse, plz, ort)
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
