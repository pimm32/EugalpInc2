using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Niveau
    {
        public string naam { get; set; }
        public decimal standaardBesmettingsgraad { get; set; }
        public decimal standaardHerkenbaarheidsgraad { get; set; }
        public decimal standaardSterftegraad { get; set; }
        public Niveau(string naam, decimal sbg, decimal shg, decimal ssg)
        {
            this.naam = naam;
            this.standaardBesmettingsgraad = sbg;
            this.standaardHerkenbaarheidsgraad = shg;
            this.standaardSterftegraad = ssg;
        }
        public Niveau()
        {

        }

    }
}
