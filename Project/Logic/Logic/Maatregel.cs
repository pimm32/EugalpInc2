using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Maatregel
    {
        public string naam { get; set; }
        public decimal straatbezettingFactor { get; set; }
        public decimal doktersbezoekenFactor { get; set; }
        public int ernst { get; set; }
        public decimal besmettingenGrens { get; set; }
        public decimal geregistreerdeBesmettingenGrens { get; set; }
        public decimal sterfteGrens { get; set; }
        public bool actief { get; set; }

        public MaatregelCategorie categorie { get; set; }
        public Niveau niveau { get; set; }

        public Maatregel(string naam, decimal sbf, decimal dbf, int ernst, decimal bg, decimal gbg, decimal sg)
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
