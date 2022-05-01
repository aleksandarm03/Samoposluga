using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samoposluga;

namespace Aplikacija_Samoposluga
{
    class Ostalo:IOstalo 
    {
        string naziv;
        double cena;
        string opis;
        public Ostalo(string naziv, double cena, string opis)
        {
            this.naziv = naziv;
            this.cena = Math.Round(cena, 2);
            this.opis = opis;
        }



        public string Prikaz()
        {
            return (naziv + "-" + cena + " RSD-Opis: " + opis);
        }
    }
}
