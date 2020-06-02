using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Maatregel
    {
        public string naam { get; set; }
        public double straatbezettingFactor { get; set; }
        public double doktersbezoekenFactor { get; set; }
        public int ernst { get; set; }
        public double besmettingenGrens { get; set; }
        public double geregistreerdeBesmettingenGrens { get; set; }
        public double sterfteGrens { get; set; }
        public bool actief { get; set; }

        public Maatregel(string naam, double sbf, double dbf, int ernst, double bg, double gbg, double sg)
        {
            this.naam = naam;
            this.straatbezettingFactor = sbf;
            this.doktersbezoekenFactor = dbf;
            this.ernst = ernst;
            this.besmettingenGrens = bg;
            this.geregistreerdeBesmettingenGrens = gbg;
            this.sterfteGrens = sg;
            this.actief = false;
        }

        public void MaatregelActiveren()
        {
            this.actief = true;
        }

        public void MaatregelDeactiveren()
        {
            this.actief = false;
        }
    }
}
