using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DalModels
{
    public class DalVirus
    {
        public string naam { get; set; }
        public decimal besmettingsgraad { get; set; }
        public decimal herkenbaarheidsgraad { get; set; }
        public decimal sterftegraad { get; set; }
        public int aantalDagenSindsEersteUitbraak { get; set; }
    }
}
