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

        public List<Land> BesmetteVerbondenLanden()
        {
            List<Land> landen = new List<Land>();
            foreach(Verbinding verbinding in this.land.VertrekkendVerkeer)
            {
                //hier controleer ik of het aantal mensen dat vertrekt uit dit land minimaal 1 besmet iemand heeft, wat een verbonden land zou besmetten
                if(verbinding.mensenVerkeer>(this.land.inwonersaantal / this.aantalBesmettingen))
                {
                    landen.Add(verbinding.aankomstLand);
                }
            }

            return landen;
        }

        public void UpdateUitbraak(decimal besmettingsgraad, decimal herkenbaarheidsgraad, decimal sterftegraad)
        {
            this.aantalBesmettingen = BerekenNieuweBesmettingen(besmettingsgraad);
            this.aantalGeregistreerdeBesmettingen = BerekenNieuweGeregistreerdeBesmettingen(herkenbaarheidsgraad);
            this.aantalSterfgevalen = BerekenNieuweSterfgevallen(sterftegraad);
        }

        public int BerekenNieuweBesmettingen(decimal besmettingsgraad)
        {
            return 1;
        }

        public int BerekenNieuweGeregistreerdeBesmettingen(decimal herkenbaarheidsgraad)
        {
            return 1;
        }

        public int BerekenNieuweSterfgevallen(decimal sterftegraad)
        {
            return 1;
        }
    }
}
