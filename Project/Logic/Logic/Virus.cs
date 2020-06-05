using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Virus
    {
        public string naam { get; set; }
        public decimal besmettingsgraad { get; set; }
        public decimal herkenbaarheidsgraad { get; set; }
        public decimal sterftegraad { get; set; }
        public int aantalDagenSindsEersteUitbraak { get; set; }
        public List<Uitbraak> uitbraken;

        public Virus(string naam, decimal bg, decimal hg, decimal sg)
        {
            this.naam = naam;
            this.besmettingsgraad = bg;
            this.herkenbaarheidsgraad = hg;
            this.sterftegraad = sg;
            this.aantalDagenSindsEersteUitbraak = 0;
        }
        public Virus(string naam, decimal bg, decimal hg, decimal sg, int dagen)
        {
            this.naam = naam;
            this.besmettingsgraad = bg;
            this.herkenbaarheidsgraad = hg;
            this.sterftegraad = sg;
            this.aantalDagenSindsEersteUitbraak = dagen;
        }

        public Virus(string naam, Niveau niveau)
        {
            this.naam = naam;
            this.besmettingsgraad = niveau.standaardBesmettingsgraad;
            this.herkenbaarheidsgraad = niveau.standaardHerkenbaarheidsgraad;
            this.sterftegraad = niveau.standaardSterftegraad;
            this.aantalDagenSindsEersteUitbraak = 0;
        }

        //
        public void UpdateVirus(List<Land> landen)
        {
            //Hier update ik elke uitbraak en voeg ik eventuele nieuwe uitbraken toe
            foreach(Uitbraak uitbraak in this.uitbraken)
            {
                //Hier controleer ik of een besmet persoon van het land van de uitbraak een ander land binnenkomt
                foreach(Land land in uitbraak.BesmetteVerbondenLanden())
                {
                    //Hier controleer ik of het land al een besmetting heeft, als dat al zo is hoeft er niets te gebeuren, zo niet wordt er een nieuwe uitbraak toegevoegd
                    if (!HeeftLandUitbraak(land))
                    {
                        VoegUitbraakToe(land);
                    }
                }
                //Hier roep ik de methode in uitbraak aan om zichzelf te updaten met de waardes van het virus
                uitbraak.UpdateUitbraak(this.besmettingsgraad, this.herkenbaarheidsgraad, this.sterftegraad);
            }
        }

        private bool HeeftLandUitbraak(Land land)
        {
            foreach(Uitbraak uitbraak in uitbraken)
            {
                if(uitbraak.land.naam == land.naam)
                {
                    return true;
                }
            }
            return false;
        }

        private void VoegUitbraakToe(Land land)
        {
            Uitbraak uitbraak = new Uitbraak(land);
            this.uitbraken.Add(uitbraak);
        }
    }
}
