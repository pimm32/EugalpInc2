using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Virus
    {
        public string naam { get; set; }
        public double besmettingsgraad { get; set; }
        public double herkenbaarheidsgraad { get; set; }
        public double sterftegraad { get; set; }
        public int aantalDagenSindsEersteUitbraak { get; set; }
        public List<Uitbraak> uitbraken;

        public Virus(string naam, double bg, double hg, double sg)
        {
            this.naam = naam;
            this.besmettingsgraad = bg;
            this.herkenbaarheidsgraad = hg;
            this.sterftegraad = sg;
            this.aantalDagenSindsEersteUitbraak = 0;
        }

        public Virus(string naam, Niveau niveau)
        {
            this.naam = naam;
            this.besmettingsgraad = niveau.standaardBesmettingsgraad;
            this.herkenbaarheidsgraad = niveau.standaardHerkenbaarheidsgraad;
            this.sterftegraad = niveau.standaardSterftegraad;
            this.aantalDagenSindsEersteUitbraak = 0;
        }

        public void VoegUitbraakToe(Land land)
        {
            Uitbraak uitbraak = new Uitbraak(land);
            this.uitbraken.Add(uitbraak);
        }
    }
}
