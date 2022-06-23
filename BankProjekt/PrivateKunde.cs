using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public class PrivateKunde: Kunde
    {

        private string vorname;
        private string nachname;
        private DateTime gebDatum = DateTime.Now;

        public PrivateKunde(int kundennummer, string vorname, string nachname, string telefonnummer, string email, DateTime gebDatum, Adresse adress) :
            base(kundennummer, telefonnummer, email, adress)
        {
            this.vorname = vorname.Trim().ToUpper();
            this.nachname = nachname.Trim().ToUpper();
            this.gebDatum = gebDatum;
        }


        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname 
        { 
            get => nachname; 
            set => nachname =  value; 
        }
        public DateTime GebDatum { get => gebDatum; set => gebDatum = value; }


        public static PrivateKunde NeuePrivateKunde(Bank b)
        {
            string vorname;
            do
            {
                vorname = IO.ReadString("Vorname: ");
            }
            while (!PrueftInput.PrueftRegex(vorname, PrueftInput.forText, PrueftInput.messageForText));

            string nachname;
            do
            {
                nachname = IO.ReadString("Nachname: ");
            }
            while (!PrueftInput.PrueftRegex(nachname, PrueftInput.forText, PrueftInput.messageForText));

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

            DateTime datum = IO.ReadDate("Geburtsdatum : ");

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

            return new PrivateKunde(
                kn + 1,
                vorname,
                nachname,
                telefon,
                email,
                datum,
                new Adresse(strasse, plz, ort)
                );
        }

        public override string ToString() => $"Privatekunden: KN : {Kundennummer}; Name : {Nachname} {Vorname} ; Geburtsdatum : {GebDatum.ToString("yyyy-MM-dd")} " +
            $"Email : {Email} - Telefon: {Telefonnummer} Adress {Adress.StrasseMitHausnummer} {Adress.Plz} {Adress.Ort}";


        public void displayInfo()
        {
            Console.WriteLine(ToString());
        }

        public static void displayName(PrivateKunde k)
        {
            Console.WriteLine(k.Nachname);
        }
    }
}
