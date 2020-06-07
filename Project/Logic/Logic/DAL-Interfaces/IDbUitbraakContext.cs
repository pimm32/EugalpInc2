using Logic.DAL_Interfaces.Dto_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbUitbraakContext
    {
        public void UitbraakOpslaanInDatabase(UitbraakDto uitbraak, VirusDto virus);
        public void UitbraakAanpassenInDatabase(UitbraakDto uitbraak, VirusDto virus);
        public IEnumerable<UitbraakDto> VraagAlleUitbrakenOpVanVirusUitDatabase(VirusDto virus);

    }
}
