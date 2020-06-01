using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class VerbindingCollectie
    {
        public List<Verbinding> verbindingen;
         public VerbindingCollectie()
        {
            verbindingen = new List<Verbinding>();
        }

        public void VoegVerbindingToe(Land vertrek, Land aankomst, int verkeer)
        {
            Verbinding verbinding = new Verbinding(vertrek, aankomst, verkeer);
            this.verbindingen.Add(verbinding);
        }
        public List<Verbinding> VraagVertrekkendeVerbindingenOpVanLand(Land land)
        {
            List<Verbinding> lijst = new List<Verbinding>();



            return lijst;
        }

        public List<Verbinding> VraagBinnenkomendeVerbindingenOpVanLand(Land land)
        {
            List<Verbinding> lijst = new List<Verbinding>();



            return lijst;
        }
    }
}
