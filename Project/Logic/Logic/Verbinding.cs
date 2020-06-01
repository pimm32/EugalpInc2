using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Verbinding
    {
        Land vertrekLand;
        Land aankomstLand;
        public int mensenVerkeer { get; set; }

        public Verbinding(Land vertrek, Land aankomst, int verkeer)
        {
            this.vertrekLand = vertrek;
            this.aankomstLand = aankomst;
            this.mensenVerkeer = verkeer;
        }

        public void VerkeerAanpassen(int nieuwVerkeer)
        {
            this.mensenVerkeer = nieuwVerkeer;
        }
    }
}
