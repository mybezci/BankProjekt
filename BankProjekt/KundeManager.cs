using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    public static class KundeManager
    {
        public static void DisplayPrivateKunde(string name, Bank b )
        {
            foreach (PrivateKunde kunde in b.Kunden)
            {
                if (kunde.Nachname.Equals(name))
                {
                    Console.WriteLine("Konten von " + kunde.Nachname);
                    foreach (Konto konto in kunde.Konten)
                    {
                        Console.WriteLine(konto.ToString());
                    }
                }
            }
        }

        public static void DisplayFirmenKunde(string name, Bank b)
        {
            foreach (FirmenKunde kunde in b.Kunden)
            {
                if (kunde.Firmenname.Equals(name))
                {
                    Console.WriteLine("Konten von " + kunde.Firmenname);
                    foreach (Konto konto in kunde.Konten)
                    {
                        Console.WriteLine(konto.ToString());
                    }
                }
            }
        }

    }
}
