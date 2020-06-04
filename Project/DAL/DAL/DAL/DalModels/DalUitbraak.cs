using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DalModels
{
    public class DalUitbraak
    {
        public int aantalBesmettingen { get; set; }
        public int aantalGeregistreerdeBesmettingen { get; set; }
        public int aantalSterfgevalen { get; set; }
        public DalLand land { get; set; }
    }
}
