using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces.Dto_models
{
    public class NiveauDto
    {
        public string naam { get; set; }
        public decimal standaardBesmettingsgraad { get; set; }
        public decimal standaardHerkenbaarheidsgraad { get; set; }
        public decimal standaardSterftegraad { get; set; }
        public NiveauDto(string naam, decimal sbg, decimal shg, decimal ssg)
        {
            this.naam = naam;
            this.standaardBesmettingsgraad = sbg;
            this.standaardHerkenbaarheidsgraad = shg;
            this.standaardHerkenbaarheidsgraad = ssg;
        }
        public NiveauDto()
        {

        }
    }
}
