using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class VirusBeheer: IVirusBeheer
    {
        private readonly IDbVirusContext _virusContext;
        private readonly IDbSymptoomContext _symptoomContext;
        public VirusBeheer(IDbVirusContext virusContext, IDbSymptoomContext symptoomContext)
        {
            _virusContext = virusContext;
            _symptoomContext = symptoomContext;
        }
        public Virus HaalVirusOpUitDatabaseBijNaam(string naam)
        {
            VirusDto virus = _virusContext.VraagVirusOpInDatabase(naam);
            Virus result = new Virus();
            result.InitieerVirus(virus.naam, virus.besmettingsgraad, virus.herkenbaarheidsgraad, virus.sterftegraad, virus.aantalDagenSindsEersteUitbraak);
            return result;
        }

        // TODO
        public void SlaVirusOpInDatabase(Virus virus)
        {
            VirusDto virusdto = new VirusDto(virus.naam, virus.besmettingsgraad, virus.herkenbaarheidsgraad, virus.sterftegraad, virus.aantalDagenSindsEersteUitbraak);
            _virusContext.VirusOpslaanInDatabase(virusdto);
            foreach (Symptoom symptoom in virus.beschikbareSymptomen)
            {
                SymptoomDto symptoomdto = new SymptoomDto(symptoom.naam, symptoom.besmettingsgraadFactor, symptoom.herkenbaarheidsgraadFactor, symptoom.sterftegraadFactor, symptoom.ernst, symptoom.prijs, symptoom.niveau, symptoom.categorie);
                _symptoomContext.SymptoomAanVirusToevoegenInDatabase(symptoomdto, virusdto);
            }
            foreach (Uitbraak uitbraak in virus.uitbraken)
            {

            }
        }


    }
}
