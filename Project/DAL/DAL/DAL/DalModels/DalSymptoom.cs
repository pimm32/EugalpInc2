using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DalModels
{
    public class DalSymptoom
    {
        public string naam { get; set; }
        public decimal besmettingsgraadFactor { get; set; }
        public decimal herkenbaarheidsgraadFactor { get; set; }
        public decimal sterftegraadFactor { get; set; }
        public int ernst { get; set; }
        public int prijs { get; set; }
    }
}
