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
        private DateTime gebDatum;

        public PrivateKunde(int kundennummer, string vorname, string nachname, string telefonnummer, string email, DateTime gebDatum, Adresse adress) :
            base(kundennummer, telefonnummer, email, adress)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.gebDatum = gebDatum;
        }

        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public DateTime GebDatum { get => gebDatum; set => gebDatum = value; }


        public static PrivateKunde NeuePrivateKunde(Bank b)
        {
            int kn = b.Kunden.Count;
            return new PrivateKunde(
                kn + 1,
                IO.ReadString("Kundenname: "),
                IO.ReadString("Nachname: "),
                IO.ReadString("Telefonnr: "),
                IO.ReadString("Email: "),
                IO.ReadDate("Geb. Datum: "),
                new Adresse(IO.ReadString("Strasse: "), IO.ReadString("Plz: "), IO.ReadString("Ort: "))
                );
        }

        public override string ToString() => $"Privatekunden: {Kundennummer} - {Nachname} {Vorname} ; " +
            $"{Email} {Telefonnummer} {Adress.ToString()}";


        public void displayInfo(PrivateKunde k)
        {
            Console.WriteLine(k.Kundennummer + " - " + k.Nachname + " " + k.Vorname + " " + k.Telefonnummer
                + " " + k.Email + " " + k.Adress);
        }
    }
}
