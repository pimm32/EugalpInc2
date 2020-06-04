using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Niveau
    {
        public string naam { get; set; }
        public double standaardBesmettingsgraad { get; set; }
        public double standaardHerkenbaarheidsgraad { get; set; }
        public double standaardSterftegraad { get; set; }
        public Niveau(string naam, double sbg, double shg, double ssg)
        {
            this.naam = naam;
            this.standaardBesmettingsgraad = sbg;
            this.standaardHerkenbaarheidsgraad = shg;
            this.standaardSterftegraad = ssg;
        }

    }
}
