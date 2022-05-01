using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikacija_Samoposluga
{
    public abstract class Proizvodi
    {
        protected string naziv;
        protected double cena;

        public Proizvodi(string naziv, double cena)
        {
            this.naziv = naziv;
            this.cena = Math.Round(cena, 2); ;
        }

        public abstract string Prikaz();

    }
}
