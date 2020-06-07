using Logic.DAL_Interfaces;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Maatregel: IMaatregel
    {
        public string naam { get; set; }
        public decimal straatbezettingFactor { get; set; }
        public decimal doktersbezoekenFactor { get; set; }
        public int ernst { get; set; }
        public decimal besmettingenGrens { get; set; }
        public decimal geregistreerdeBesmettingenGrens { get; set; }
        public decimal sterfteGrens { get; set; }
        public bool actief { get; set; }

        public string categorie { get; set; }
        public string niveau { get; set; }

        public Maatregel(string naam, decimal sbf, decimal dbf, int ernst, decimal bg, decimal gbg, decimal sg, string cat, string niv)
        {
            this.naam = naam;
            this.straatbezettingFactor = sbf;
            this.doktersbezoekenFactor = dbf;
            this.ernst = ernst;
            this.besmettingenGrens = bg;
            this.geregistreerdeBesmettingenGrens = gbg;
            this.sterfteGrens = sg;
            this.actief = false;
            this.categorie = cat;
            this.niveau = niv;
        }

        public void MaatregelActiveren()
        {
            this.actief = true;
        }

        public void MaatregelDeactiveren()
        {
            this.actief = false;
        }

        public bool MoetMaatregelGeactiveerdWorden(decimal besmGr, decimal gerBesmGr, decimal SteGr)
        {
            if(besmGr >= this.besmettingenGrens || gerBesmGr >= this.geregistreerdeBesmettingenGrens || SteGr >= this.sterfteGrens)
            {
                return true;
            }
            return false;
        }
    }
}
