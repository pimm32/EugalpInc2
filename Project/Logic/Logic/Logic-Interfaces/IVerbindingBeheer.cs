using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface IVerbindingBeheer
    {
        public void VerbindingOpslaanInDatabase(Verbinding verbinding);
        public void VerbindingAanpassenInDatabase(Verbinding verbinding);
        public List<Verbinding> AlleVerbindingenVanLand(Land land);
        public List<Verbinding> AlleVerbindingen();

    }
}
