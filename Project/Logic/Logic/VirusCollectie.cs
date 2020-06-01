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

        public void VirusToevoegen(string naam, decimal bg, decimal hg, decimal sg)
        {
            Virus virus = new Virus(naam, bg, hg, sg);
            this.virussen.Add(virus);
        }
    }
}
