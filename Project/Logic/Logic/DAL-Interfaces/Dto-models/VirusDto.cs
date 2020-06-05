using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces.Dto_models
{
    public class VirusDto
    {
        public string naam { get; set; }
        public decimal besmettingsgraad { get; set; }
        public decimal herkenbaarheidsgraad { get; set; }
        public decimal sterftegraad { get; set; }
        public int aantalDagenSindsEersteUitbraak { get; set; }
        public VirusDto(string naam, decimal bg, decimal hg, decimal sg, int dagen)
        {
            this.naam = naam;
            this.besmettingsgraad = bg;
            this.herkenbaarheidsgraad = hg;
            this.sterftegraad = sg;
            this.aantalDagenSindsEersteUitbraak = dagen;
        }
    }
}
