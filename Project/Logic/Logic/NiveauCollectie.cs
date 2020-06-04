using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class NiveauCollectie
    {
        List<Niveau> niveaus;

        public NiveauCollectie()
        {
            niveaus = new List<Niveau>();
        }

        public void NiveauToevoegen(string naam, double sbg, double shg, double ssg)
        {
            niveaus.Add(new Niveau(naam, sbg, shg, ssg));
        }

        public Niveau HaalNiveauOpBijNaam(string naam)
        {
            foreach(Niveau niveau in niveaus)
            {
                if(niveau.naam == naam)
                {
                    return niveau;
                }
            }
            throw new NotImplementedException();
        }
    }
}
