using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces.Dto_models
{
    public class LandDto
    {
        public string naam { get; set; }
        public int inwonersaantal { get; set; }
        public decimal straatbezetting { get; set; }
        public decimal doktersbezoeken { get; set; }

        public LandDto(string naam, int inwonersaantal, decimal straatbezetting, decimal doktersbezoeken)
        {
            this.naam = naam;
            this.inwonersaantal = inwonersaantal;
            this.straatbezetting = straatbezetting;
            this.doktersbezoeken = doktersbezoeken;
        }
        public LandDto()
        {

        }
    }
}
