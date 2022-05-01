using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacija_Samoposluga
{
    class Pica:Proizvodi
    {
         public bool alkohol;
        public Pica(string naziv, double cena, bool alkohol)
            : base(naziv, cena)
        {
            this.alkohol = alkohol;
        }

        public override string Prikaz()
        {
            if(alkohol)
            return (naziv + "- alkoholno " + cena + " RSD " );
            else
                return (naziv + "- bezalkoholno " + cena + " RSD ");
        }
    }
}
