using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacija_Samoposluga
{
    class Mlecni:Proizvodi
    {
        public int rok;
        public Mlecni(string naziv, double cena, int rok)
            : base(naziv, cena)
        {
            this.rok = rok;
        }

        public override string Prikaz()
        {

            return (naziv + "-" + cena + " Rok trajanja: " + rok+" dana");
        }
    }
}
