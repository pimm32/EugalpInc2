using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eugalp.Models.ViewModels
{
    public class NiveauViewModel
    {
        public string naam { get; set; }
        public decimal standaardBesmettingsgraad { get; set; }
        public decimal standaardHerkenbaarheidsgraad { get; set; }
        public decimal standaardSterftegraad { get; set; }
    }
}
