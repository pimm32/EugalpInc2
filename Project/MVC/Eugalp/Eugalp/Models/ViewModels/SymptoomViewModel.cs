using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eugalp.Models.ViewModels
{
    public class SymptoomViewModel
    {
        public string naam { get; set; }
        public decimal besmettingsgraadFactor { get; set; }
        public decimal herkenbaarheidsgraadFactor { get; set; }
        public decimal sterftegraadFactor { get; set; }
        public int ernst { get; set; }
        public int prijs { get; set; }
        public string niveau { get; set; }
        public string categorie { get; set; }
    }
}
