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

        public static void FindKontenVonPrivateKunde(string input, Bank b)
        {
            try
            {
                foreach (Kunde kunde in b.Kunden)
                {
                    if (kunde.Konten != null && kunde.Konten.Count >= 0)
                    {
                        if (input.Equals(kunde.Kundennummer))
                      
                        {
                            int ind = b.Kunden.FindIndex(x => x.Konten.Equals(input));
                            Console.WriteLine("Index von PrivateKunden ->" + ind);
                            Console.WriteLine(b.Kunden[ind].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Konten ist nulllll");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }



        public static void DisplayKontenVonPrivateKunden(Bank b)
        {
            foreach (PrivateKunde item in b.Kunden)
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
                }
            }
            else
            {
                throw new Exception("Nulll");
            }
        }


    }
}
