using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class VirusCollectie
    {
        public List<Virus> virussen;
        
        public VirusCollectie()
        {
            virussen = new List<Virus>();
        }

        public void VirusToevoegen(string naam, double bg, double hg, double sg)
        {
            Virus virus = new Virus(naam, bg, hg, sg);
            this.virussen.Add(virus);
        }

        public void VirusToevoegen(string naam, string niveaunaam)
        {
            NiveauCollectie NC = new NiveauCollectie();
            Niveau niveau = NC.HaalNiveauOpBijNaam(niveaunaam);
            Virus virus = new Virus(naam, niveau);
            this.virussen.Add(virus);
        }

        public Virus HaalVirusOp(string naam)
        {
            foreach(Virus virus in virussen)
            {
                if(virus.naam == naam)
                {
                    return virus;
                }
            }
            throw new NotImplementedException();
        }
    }
}
