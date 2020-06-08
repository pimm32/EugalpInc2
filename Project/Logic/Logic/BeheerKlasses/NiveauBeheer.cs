using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class NiveauBeheer: INiveauBeheer
    {
        private readonly IDbNiveauContext _context;

        public NiveauBeheer(IDbNiveauContext context)
        {
            _context = context;
        }

        public Niveau SelecteerNiveau(string naam)
        {
            NiveauDto nd =_context.VraagNiveauOpUitDatabase(naam);
            return new Niveau(nd.naam, nd.standaardBesmettingsgraad, nd.standaardHerkenbaarheidsgraad, nd.standaardSterftegraad);
        }

        public List<Niveau> AlleNiveaus()
        {
            List<Niveau> resultaat = new List<Niveau>();
            IEnumerable<NiveauDto> nds = _context.AlleNiveaus();
            foreach (NiveauDto nd in nds)
            {
                resultaat.Add(new Niveau(nd.naam, nd.standaardBesmettingsgraad, nd.standaardHerkenbaarheidsgraad, nd.standaardSterftegraad));

            }

            return resultaat;
        }
    }
}
