using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces.Dto_models
{
    public class SymptoomDto
    {
        public string naam { get; set; }
        public decimal besmettingsgraadFactor { get; set; }
        public decimal herkenbaarheidsgraadFactor { get; set; }
        public decimal sterftegraadFactor { get; set; }
        public int ernst { get; set; }
        public int prijs { get; set; }
        public bool actief { get; set; }
        public string niveau { get; set; }
        public string categorie { get; set; }
        public SymptoomDto()
        {
            //all props
        }
    }
}
