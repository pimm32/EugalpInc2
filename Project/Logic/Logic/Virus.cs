﻿using System;
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

        public void UpdateVirus(List<Land> landen)
        {
            foreach(Uitbraak uitbraak in this.uitbraken)
            {

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
