using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Uitbraak
    {
        public Land land;
        public int aantalBesmettingen { get; set; }
        public int aantalGeregistreerdeBesmettingen { get; set; }
        public int aantalSterfgevalen { get; set; }

        public Uitbraak(Land land)
        {
            this.land = land;
            this.aantalBesmettingen = 1;
            this.aantalGeregistreerdeBesmettingen = 0;
            this.aantalSterfgevalen = 0;
        }

        public void BerekenNieuweBesmettingen(Decimal besmettingsgraad)
        {
            
        }

        public void BerekenNieuweGeregistreerdeBesmettingen(Decimal herkenbaarheidsgraad)
        {

        }

        public void BerekenNieuweSterfgevallen(Decimal sterftegraad)
        {

        }
    }
}
