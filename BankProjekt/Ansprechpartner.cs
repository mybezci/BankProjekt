using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public class Ansprechpartner
    {
        private string vorname;
        private string nachname;
        private string telefonnummer;

        public Ansprechpartner(string vorname, string nachname, string telefonnummer)
        {
            this.vorname = vorname.Trim().ToUpper();
            this.nachname = nachname.Trim().ToUpper();
            this.telefonnummer = telefonnummer.Trim().ToUpper();
        }

        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public string Telefonnummer { get => telefonnummer; set => telefonnummer = value; }
    }
}
