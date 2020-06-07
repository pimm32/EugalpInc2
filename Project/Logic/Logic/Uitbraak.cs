using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        public List<Land> BesmetteVerbondenLanden()
        {
            List<Land> landen = new List<Land>();
            foreach(Verbinding verbinding in this.land.VertrekkendVerkeer)
            {
                decimal factor = ((decimal)aantalBesmettingen / (decimal)land.inwonersaantal);
                //hier controleer ik of het aantal mensen dat vertrekt uit dit land gemiddeld 1 besmet iemand heeft, wat een verbonden land zou besmetten
                if(verbinding.mensenVerkeer *(factor) >= 1)
                {
                    landen.Add(verbinding.aankomstLand);
                }
            }

            return landen;
        }

        public void UpdateUitbraak(decimal besmettingsgraad, decimal herkenbaarheidsgraad, decimal sterftegraad)
        {
            this.aantalBesmettingen += (int)((aantalBesmettingen - aantalSterfgevalen) * besmettingsgraad);
            //Hier controleer ik of het aantal besmettingen niet hoger is dan het aantal inwoners
            if(aantalBesmettingen > land.inwonersaantal)
            {
                aantalBesmettingen = land.inwonersaantal;
            }
            this.aantalGeregistreerdeBesmettingen += (int)((aantalBesmettingen - aantalSterfgevalen) * herkenbaarheidsgraad);
            //Hier controleer ik of het aantal geregistreerde besmettingen niet hoger is dan het aantal besmettingen
            if(aantalGeregistreerdeBesmettingen > aantalBesmettingen)
            {
                aantalGeregistreerdeBesmettingen = aantalBesmettingen;
            }
            this.aantalSterfgevalen += (int)((aantalBesmettingen - aantalSterfgevalen) * sterftegraad);
            //Hier controleer ik of het aantal sterfgevallen niet hoger is dan het aantal besmettingen <wat praktisch nooit kan voorkomen omdat sterftegraad niet groter dan 1 hoort te zijn
            if(aantalSterfgevalen > aantalBesmettingen)
            {
                aantalSterfgevalen = aantalBesmettingen;
            }
        }

        
    }
}
