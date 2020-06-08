using Logic.DAL_Interfaces.Dto_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbNiveauContext
    {
        public NiveauDto VraagNiveauOpUitDatabase(string niveau);
        public IEnumerable<NiveauDto> AlleNiveaus();
    }
}
