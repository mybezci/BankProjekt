using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace BankProjekt
{
    public class Trart
    {
        private List<string> art = new List<string>() { "Einzahlung", "Auszahlung" };
        private string einzahlung = "Einzahlung";
        private string auszahlung = "Auszahlung";

        public string Einzahlung { get => einzahlung; set => einzahlung = value; }
        public string Auszahlung { get => auszahlung; set => auszahlung = value; }
        public List<string> Art { get => art; set => art = value; }

    }
}
