using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces.Dto_models
{
    public class VerbindingDto
    {
        public string vertrekLand;
        public string aankomstLand;
        public int mensenVerkeer { get; set; }
        public VerbindingDto(string a, string b, int c)
        {
            this.vertrekLand = a;
            this.aankomstLand = b;
            this.mensenVerkeer = c;
        }
    }
}
