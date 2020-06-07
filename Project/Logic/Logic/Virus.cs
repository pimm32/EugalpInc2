using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Virus
    {
        public string naam { get; private set; }
        public decimal besmettingsgraad { get; private set; }
        public decimal herkenbaarheidsgraad { get; private set; }
        public decimal sterftegraad { get; private set; }
        public int aantalDagenSindsEersteUitbraak { get; private set; }
        public List<Uitbraak> uitbraken;
        public List<Symptoom> beschikbareSymptomen { get; set; }

        static Virus()
        {

        }

        public void InitieerVirus(string naam, decimal bg, decimal hg, decimal sg, List<Symptoom> symptomen)
        {
            this.naam = naam;
            this.besmettingsgraad = bg;
            this.herkenbaarheidsgraad = hg;
            this.sterftegraad = sg;
            this.aantalDagenSindsEersteUitbraak = 0;
            SymptomenToevoegen(symptomen);
        }

        public void InitieerVirus(string naam, decimal bg, decimal hg, decimal sg, int dagen)
        {
            this.naam = naam;
            this.besmettingsgraad = bg;
            this.herkenbaarheidsgraad = hg;
            this.sterftegraad = sg;
            this.aantalDagenSindsEersteUitbraak = dagen;
        }

        public void InitieerVirus(string naam, Niveau niveau)
        {
            this.naam = naam;
            this.besmettingsgraad = niveau.standaardBesmettingsgraad;
            this.herkenbaarheidsgraad = niveau.standaardHerkenbaarheidsgraad;
            this.sterftegraad = niveau.standaardSterftegraad;
            this.aantalDagenSindsEersteUitbraak = 0;
        }
        //Hier voeg ik alle symptomen toe aan de lijst met beschikbare symptomen
        private void SymptomenToevoegen(List<Symptoom> symptomen)
        {
            foreach (Symptoom symptoom in symptomen)    
            {
                if (!BestaatSymptoomAlInLijst(symptoom))
                {
                    this.beschikbareSymptomen.Add(symptoom);
                }
            }
        }

        //Hier controleer ik of een symptoom al bestaat in de lijst met beschikbare symptomen
        private bool BestaatSymptoomAlInLijst(Symptoom symptoom)
        {
            foreach (Symptoom symptoom1 in this.beschikbareSymptomen)
            {
                if (symptoom1.naam == symptoom.naam && symptoom1.niveau == symptoom.niveau)
                {
                    return true;
                }
            }
            return false;
        }
        //Hier wordt het symptoom geactiveerd
        public void SymptoomActiveren(Symptoom symptoom)
        {
            foreach (Symptoom symptoom1 in this.beschikbareSymptomen)
            {
                if(symptoom1.naam == symptoom.naam && symptoom1.niveau == symptoom.niveau)
                {
                    ActiveerSymptoom(symptoom1);
                }
            }
        }
        private void ActiveerSymptoom(Symptoom symptoom)
        {
            foreach (Symptoom symptoom1 in beschikbareSymptomen)
            {
                if(symptoom.naam == symptoom1.naam && symptoom.niveau == symptoom1.niveau)
                {
                    symptoom1.SymptoomActiveren();
                    VirusWaardeUpdaten(symptoom1.besmettingsgraadFactor, symptoom1.herkenbaarheidsgraadFactor, symptoom1.sterftegraadFactor);
                    
                }

                else if(symptoom.categorie == symptoom1.categorie && symptoom1.ernst > symptoom.ernst)
                {
                    symptoom1.SymptoomDeactiveren();
                    VirusWaardeUpdaten((1 / symptoom1.besmettingsgraadFactor), (1 / symptoom1.herkenbaarheidsgraadFactor), (1 / symptoom1.sterftegraadFactor));
                }
            }
        }

        //Hier update ik het virus, ik geef een lijst met landen mee vanuit de controller, omdat deze lijst statisch is in de klasse 'landBeheer' 
        // Ook is het niet van belang voor het virus om alle landen van de wereld lokaal op te slaan, omdat een virus alleen 'communiceert'
        // met landen waar een uitbraak is, dus met een uitbraak (van een land)
        public void UpdateVirus(List<Land> landen)
        {
            //Hier update ik elke uitbraak en voeg ik eventuele nieuwe uitbraken toe
            foreach(Uitbraak uitbraak in this.uitbraken)
            {
                //Hier roep ik de methode in uitbraak aan om zichzelf te updaten met de waardes van het virus
                uitbraak.UpdateUitbraak(this.besmettingsgraad, this.herkenbaarheidsgraad, this.sterftegraad);

                //Hier controleer ik of een besmet persoon van het land van de uitbraak een ander land binnenkomt
                foreach (Land land in uitbraak.BesmetteVerbondenLanden())
                {
                    //Hier controleer ik of het land al een besmetting heeft, als dat al zo is hoeft er niets te gebeuren, zo niet wordt er een nieuwe uitbraak toegevoegd
                    if (!HeeftLandUitbraak(land))
                    {
                        VoegUitbraakToe(LandUitLijstLandenSelecteren(landen, land));
                    }
                }
                
            }
        }

        //Aangezien ik niet alle informatie opsla in de verbindingen tussen landen (alleen de naam van het land, wat een primaire index is voor land)
        //Selecteer ik hier het land uit de meegegeven lijst van alle landen (met informatie, ie: alle maatregels en 
        private Land LandUitLijstLandenSelecteren(List<Land> landen, Land land)
        {
            foreach (Land land1 in landen)
            {
                if(land1.naam == land.naam)
                {
                    return land1;
                }
            }
            //situatie kan niet voorkomen omdat land land uit dezelfde database geladen wordt, en de lijst met landen alle landen uit de database zijn, ie: land land bestaat niet zonder list<land> landen
            throw new Exception("Land komt niet voor in de lijst met beschikbare landen");
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

        public void VoegUitbraakToe(Land land)
        {
            Uitbraak uitbraak = new Uitbraak(land);
            this.uitbraken.Add(uitbraak);
        }

        private void VirusWaardeUpdaten(decimal bG, decimal hG, decimal sG)
        {
            this.besmettingsgraad *= bG;
            this.herkenbaarheidsgraad *= hG;
            this.sterftegraad *= sG;
        }
    }
}
