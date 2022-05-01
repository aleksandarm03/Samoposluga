using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacija_Samoposluga
{
    class Zacini:Proizvodi
    {
        public string zemlja_uvoza;
        public Zacini(string naziv, double cena, string zemlja_uvoza)
            : base(naziv, cena)
        {
            this.zemlja_uvoza = zemlja_uvoza;
        }

        public override string Prikaz()
        {

            return (naziv + " " + zemlja_uvoza +"-"+ cena + " RSD");
        }
    }
}
