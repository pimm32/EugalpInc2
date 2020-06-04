using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbVerbindingContext
    {
        public void VerbindingOpslaanInDatabase(Verbinding verbinding);
        public void VerbindingAanpassenInDatabase(Verbinding verbinding);
        public void VerbindingVerwijderenUitDatabase(Verbinding verbinding);
        public IEnumerable<Verbinding> VraagInkomendeVerbindingenOpVanLand(Land land);
        public IEnumerable<Verbinding> VraagUitgaandeVerbindingenOpVanLand(Land land);


    }
}
