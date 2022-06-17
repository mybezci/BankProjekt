using System;

namespace BankProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}




namespace Util
{
    class IO
    {
        public static String ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        public static int ReadInteger(string prompt)
        {
            int i;
            Int32.TryParse(ReadString(prompt), out i);
            return i;
        }
        public static double ReadDouble(string prompt)
        {
            double d;
            Double.TryParse(ReadString(prompt), out d);
            return d;
        }
        public static DateTime ReadDate(string prompt)
        {
            DateTime d;
            DateTime.TryParse(ReadString(prompt), out d);
            return d;
        }

    }
}
