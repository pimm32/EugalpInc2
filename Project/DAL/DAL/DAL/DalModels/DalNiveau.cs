using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DalModels
{
    public class DalNiveau
    {
        public string naam { get; set; }
        public decimal standaardBesmettingsgraad { get; set; }
        public decimal standaardHerkenbaarheidsgraad { get; set; }
        public decimal standaardSterftegraad { get; set; }
    }
}
