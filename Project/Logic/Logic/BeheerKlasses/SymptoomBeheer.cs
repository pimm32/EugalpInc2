using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Logic
{
    public class SymptoomBeheer: ISymptoomBeheer
    {
        private readonly IDbSymptoomContext _context;

        public SymptoomBeheer(IDbSymptoomContext context)
        {
            _context = context;
        }

        public Symptoom OpvragenNaarNaam(string naam, string niveau)
        {
            SymptoomDto sd = _context.SymptoomSelecteren(naam, niveau);
            Symptoom symptoom = new Symptoom(sd.naam, sd.besmettingsgraadFactor, sd.herkenbaarheidsgraadFactor, sd.sterftegraadFactor, sd.ernst, sd.prijs, sd.niveau, sd.categorie);
            return symptoom;
        }

        public void SymptoomToevoegen(Symptoom symptoom)
        {
            SymptoomDto symptoomDto = new SymptoomDto(symptoom.naam, symptoom.besmettingsgraadFactor, symptoom.herkenbaarheidsgraadFactor, symptoom.sterftegraadFactor, symptoom.ernst, symptoom.prijs, symptoom.niveau, symptoom.categorie);

            _context.SymptoomOpslaanInDatabase(symptoomDto);
        }

        public void SymptoomAanpassen(Symptoom symptoom)
        {
            SymptoomDto symptoomDto = new SymptoomDto(symptoom.naam, symptoom.besmettingsgraadFactor, symptoom.herkenbaarheidsgraadFactor, symptoom.sterftegraadFactor, symptoom.ernst, symptoom.prijs, symptoom.niveau, symptoom.categorie);

            _context.SymptoomAanpassenInDatabase(symptoomDto);
        }

        public void SymptoomVerwijderen(Symptoom symptoom)
        {
            SymptoomDto symptoomDto = new SymptoomDto(symptoom.naam, symptoom.besmettingsgraadFactor, symptoom.herkenbaarheidsgraadFactor, symptoom.sterftegraadFactor, symptoom.ernst, symptoom.prijs, symptoom.niveau, symptoom.categorie);

            _context.SymptoomVerwijderenUitDatabase(symptoomDto);
        }

        public IEnumerable<Symptoom> AlleSymptomen()
        {
            List<Symptoom> result = new List<Symptoom>();
            IEnumerable<SymptoomDto> alleDtoSymptomen = _context.VraagAlleSymptomenOp();
            foreach (SymptoomDto sd in alleDtoSymptomen)
            {
                Symptoom symptoom = new Symptoom(sd.naam, sd.besmettingsgraadFactor, sd.herkenbaarheidsgraadFactor, sd.sterftegraadFactor, sd.ernst, sd.prijs, sd.niveau, sd.categorie);
                result.Add(symptoom);
            }
            return result;
        }

        public IEnumerable<Symptoom> AlleSymptomenVanNiveau(string niveau)
        {
            List<Symptoom> result = new List<Symptoom>();
            IEnumerable<SymptoomDto> alleDtoSymptomen = _context.VraagAlleSymptomenOp();
            foreach (SymptoomDto sd in alleDtoSymptomen)
            {
                Symptoom symptoom = new Symptoom(sd.naam, sd.besmettingsgraadFactor, sd.herkenbaarheidsgraadFactor, sd.sterftegraadFactor, sd.ernst, sd.prijs, sd.niveau, sd.categorie);
                result.Add(symptoom);
            }
            return result;
        }

    }
}
