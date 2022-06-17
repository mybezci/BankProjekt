using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public abstract class Kunde
    {
        private List<Konto> konten;
        private List<PrivateKunde> privateKunden;
        private int kundennummer = 1;
        private string telefonnummer;
        private string email;
        private Adresse adress;

        public Kunde(int kundennummer, string telefonnummer, string email, Adresse adress)
        {
            this.kundennummer = kundennummer;
            this.telefonnummer = telefonnummer;
            this.email = email;
            this.adress = adress;
        }



        public List<Konto> Konten { get => konten; set => konten = value; }
        public int Kundennummer { get => kundennummer; set => kundennummer = value; }
        public string Telefonnummer { get => telefonnummer; set => telefonnummer = value; }
        public string Email { get => email; set => email = value; }
        public Adresse Adress { get => adress; set => adress = value; }




        public void DisplayAllKontenVonUser()
        {

            try
            {
                if (Konten != null && Konten.Count >= 0)
                {
                    foreach (Konto konto in Konten)
                    {
                        Console.WriteLine("IBAN   -> " + konto.Iban + "  Kontostand    ->" + konto.KontoStand);
                    }
                }
                else
                {
                    Console.WriteLine("Kein Konto");
                }

            }
            catch (Exception)
            {
                throw new Exception("Konten ist null");

            }
        }

    }
}
