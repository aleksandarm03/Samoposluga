using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacija_Samoposluga
{
    class Peciva:Proizvodi
    {
        public string naziv_peakre;
        public Peciva(string naziv, double cena, string naziv_peakre)
            : base(naziv, cena)
        {
            this.naziv_peakre = naziv_peakre;
        }

        public override string Prikaz()
        {

            return (naziv + "-" + cena + " Pekara " + naziv_peakre);
        }
    }
}
