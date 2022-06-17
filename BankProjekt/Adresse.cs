using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public class Adresse
    {
        private string strasseMitHausnummer;
        private string plz;
        private string ort;

        public Adresse(string strasseMitHausnummer, string plz, string ort)
        {
            this.strasseMitHausnummer = strasseMitHausnummer;
            this.plz = plz;
            this.ort = ort;
        }

        public string StrasseMitHausnummer { get => strasseMitHausnummer; set => strasseMitHausnummer = value; }
        public string Plz { get => plz; set => plz = value; }
        public string Ort { get => ort; set => ort = value; }

        public override string ToString() => $" {StrasseMitHausnummer} - {Ort} {Plz}";

    }
}
