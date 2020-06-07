using Logic.DAL_Interfaces.Dto_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbLandContext
    {
        public IEnumerable<LandDto> VraagAlleLandenOpUitDatabase();
        public LandDto VraagLandOp(string naam);
    }
}
