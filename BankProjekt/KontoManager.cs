using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public static class KontoManager
    {
        public static void DisplayAllKonten(Bank b)
        {
            foreach (Kunde item in b.Kunden)
            {
                try
                {
                    if (item.Konten != null && item.Konten.Count >= 0)
                    {
                        foreach (Konto konto in item.Konten)
                        {
                            Console.WriteLine("IBAN   -> " + konto.Iban + "  Kontostand    ->" + konto.KontoStand);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Konten ist null");
                }

            }
        }

        public static void NeuesKontoZumKunde(Bank bank, Kunde kunde, Konto konto)
        {

            //kunde.Konten = new List<Konto>();
            if (kunde.Konten != null)
            {
                int kontoanzahl = kunde.Konten.Count;
                Console.WriteLine("Kontoanzahl  -> " + kontoanzahl);

                if (kontoanzahl >= 0 && kontoanzahl <= 10)
                {
                    konto = konto.KontoAnlegen(bank);
                    kunde.Konten.Add(konto);

                    Console.WriteLine("Konto angelegt");
                }
                else if (kontoanzahl > 10)
                {
                    Console.WriteLine("man darf max 10 Konten");
                }
                else
                {
                    throw new Exception("Konto Exception");

                    //b.Kunden[ind].DisplayAllKonten();

                }
            }
            else
            {
                throw new Exception("Nulll");
            }
        }


    }
}
