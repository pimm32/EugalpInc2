using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbUitbraakContext
    {
        public void UitbraakOpslaanInDatabase(Uitbraak uitbraak, Virus virus);
        public void UitbraakAanpassenInDatabase(Uitbraak uitbraak, Virus virus);
        public IEnumerable<Uitbraak> VraagAlleUitbrakenOpVanVirusUitDatabase(Virus virus);

    }
}
