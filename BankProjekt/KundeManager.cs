using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public static class KundeManager
    {

        public static Kunde FindKundeDurchKundennummer(int kundennummer, Bank bank)
        {

            Kunde kunde = null;
            try
            {
                if (bank.Kunden != null && bank.Kunden.Count != 0)
                {
                    int ind = bank.Kunden.FindIndex(x => x.Kundennummer.Equals(kundennummer));

                    if (ind < 0 || ind > bank.Kunden.Count - 1)
                    {
                        kunde = null;
                        Console.WriteLine("Kunde kann nicht gefunden werden!!!");
                    }
                    else
                    {
                        kunde = bank.Kunden[ind];
                    }

                }
                else
                {
                    Console.WriteLine("Falsche Kundennummer");
                }
            }
            catch (Exception)
            {
            }
            return kunde;
        }

        public static void DisplayKundeDurchIban(string inputIban, Bank b)
        {
            try
            {
                if (b.Kunden != null && b.Kunden.Count != 0)
                {
                    foreach (Kunde kunde in b.Kunden)
                    {
                        Console.WriteLine(KontoManager.FindEinKontoDurchIban(inputIban, kunde).ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Kein Ergebnis");
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Kein Ergebnis"); ;
            }
        }

        public static void DisplayPrivateKunde(string name, Bank b )
        {
            try
            {
                if (b.Kunden != null && b.Kunden.Count != 0)
                {
                    foreach (PrivateKunde kunde in b.Kunden)
                    {
                        if (kunde.Nachname.Equals(name.Trim().ToUpper()))
                        {
                            Console.WriteLine("Konten von " + kunde.Nachname);
                            foreach (Konto konto in kunde.Konten)
                            {
                                Console.WriteLine(konto.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Privatekunde wurde nicht gefunden!!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Kein Ergebnis");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Kein Ergebnis");
            }
        }

        public static void DisplayFirmenKunde(string name, Bank b)
        {
            try
            {
                if (b.Kunden != null && b.Kunden.Count != 0)
                {
                    foreach (FirmenKunde kunde in b.Kunden)
                    {
                        if (kunde.Firmenname.Equals(name.Trim().ToUpper()))
                        {
                            Console.WriteLine("Konten von " + kunde.Firmenname);
                            foreach (Konto konto in kunde.Konten)
                            {
                                Console.WriteLine(konto.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Firmenkunde wurde nicht gefunden!!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Kein Ergebnis");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Kein Ergebnis");
            }
        }

    }
}
