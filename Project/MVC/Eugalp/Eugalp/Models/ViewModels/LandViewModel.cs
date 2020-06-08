using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eugalp.Models.ViewModels
{
    public class LandViewModel
    {
        public string naam { get; set; }
        public int inwonersaantal { get; set; }
        public decimal straatbezetting { get; set; }
        public decimal doktersbezoeken { get; set; }
    }
}
