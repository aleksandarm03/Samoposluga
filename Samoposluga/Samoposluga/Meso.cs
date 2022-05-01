using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacija_Samoposluga
{
    class Meso:Proizvodi
    {
         public bool kosti;
        public Meso(string naziv, double cena, bool kosti)
            : base(naziv, cena)
        {
            this.kosti = kosti;
        }

        public override string Prikaz()
        {
            if(kosti)
            return (naziv + " sa kostima-" + cena + " RSD " );
            else
                return (naziv + "- bez kosiju" + cena + " RSD ");
        }
    }
}
