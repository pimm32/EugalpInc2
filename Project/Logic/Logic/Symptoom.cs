using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Symptoom
    {
        public string naam { get; set; }
        public decimal besmettingsgraadFactor { get; set; }
        public decimal herkenbaarheidsgraadFactor { get; set; }
        public decimal sterftegraadFactor { get; set; }
        public int ernst { get; set; }
        public int prijs { get; set; }
        public bool actief { get; set; }

        public Niveau niveau { get; set; }
        public SymptoomCategorie categorie { get; set; }

        public Symptoom(string naam, decimal bgf, decimal hgf, decimal sgf, int ernst, int prijs)
        {
            this.naam = naam;
            this.besmettingsgraadFactor = bgf;
            this.herkenbaarheidsgraadFactor = hgf;
            this.sterftegraadFactor = sgf;
            this.ernst = ernst;
            this.prijs = prijs;
            this.actief = false;
        }

        public void SymptoomActiveren()
        {
            this.actief = true;
        }

        public void SymptoomDeactiveren()
        {
            this.actief = false;
        }
    }
}
