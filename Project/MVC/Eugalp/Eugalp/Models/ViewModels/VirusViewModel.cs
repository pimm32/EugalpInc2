using Logic;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eugalp.Models.ViewModels
{
    public class VirusViewModel
    {
        [Required]
        public string naam { get;  set; }
        public decimal besmettingsgraad { get;  set; }
        public decimal herkenbaarheidsgraad { get;  set; }
        public decimal sterftegraad { get;  set; }
        public int aantalDagenSindsEersteUitbraak { get;  set; }
        public List<Uitbraak> uitbraken;
        public List<Symptoom> beschikbareSymptomen { get; set; }
    }
}
