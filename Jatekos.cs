using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFL
{
    internal class Jatekos
    {
        public string Nev { get; set; }
        public int Yardok { get; set; }
        public int Kiserletek { get; set; }
        public int Sikeres { get; set; }
        public int TDpasszok { get; set; }
        public int Eladott { get; set; }
        public double IrMutato { get; set; }
        public string Egyetem { get; set; }
        public int YardMeterben
        {
            get
            {
                return (int)Math.Round(Yardok * 0.9144);
            }
        }

        public Jatekos(string sor)
        {
            string[] adat = sor.Split(';');
            Nev = adat[0];
            Yardok = int.Parse(adat[1]);
            Kiserletek = int.Parse(adat[2]);
            Sikeres = int.Parse(adat[3]);
            TDpasszok = int.Parse(adat[4]);
            Eladott = int.Parse(adat[5]);
            IrMutato = Konvertal(adat[6]);
            Egyetem = adat[7];
        }

        private double Konvertal(string iranyitoMutato)
        {
            var decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            iranyitoMutato = iranyitoMutato.Replace(",", decimalSeparator).Replace(".", decimalSeparator);
            if (double.TryParse(iranyitoMutato, out var ertek))
                return ertek;
            throw new FormatException("Hibás érték (irányítómutató)");
        }

        public string FormazottNev(string nev)
        {
            var n = nev.Split(' ');
            n[n.Length - 1] = n[n.Length - 1].ToUpper();
            return string.Join(" ", n);
        }
    }
}
