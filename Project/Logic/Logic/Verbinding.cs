using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Verbinding
    {
        public Land vertrekLand;
        public Land aankomstLand;
        public int mensenVerkeer { get; set; }

        public Verbinding(Land vertrek, Land aankomst, int verkeer)
        {
            this.vertrekLand = vertrek;
            this.aankomstLand = aankomst;
            this.mensenVerkeer = verkeer;
        }
        public Verbinding()
        {

        }

        public void VerkeerAanpassen(int nieuwVerkeer)
        {
            this.mensenVerkeer = nieuwVerkeer;
        }
    }
}
