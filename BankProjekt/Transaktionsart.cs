using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public class Transaktionsart
    {
        private Transaktion einzahlung;
        private Transaktion auszahlung;

        public Transaktionsart(Transaktion einzahlung)
        {
            this.einzahlung = einzahlung;
        }

        public Transaktion Einzahlung { get => einzahlung; set => einzahlung = value; }
        public Transaktion Auszahlung { get => auszahlung; set => auszahlung = value; }
    }
}
