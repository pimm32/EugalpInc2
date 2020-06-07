using Logic.DAL_Interfaces.Dto_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbVerbindingContext
    {
        public void VerbindingOpslaanInDatabase(VerbindingDto verbinding);
        public void VerbindingAanpassenInDatabase(VerbindingDto verbinding);
        public void VerbindingVerwijderenUitDatabase(VerbindingDto verbinding);
        public IEnumerable<VerbindingDto> AlleVerbindingen();
        public IEnumerable<VerbindingDto> VerbindingenVanLandOpvragen(string land);
    }
}
