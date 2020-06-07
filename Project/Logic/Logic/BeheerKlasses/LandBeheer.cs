using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class LandBeheer: ILandBeheer
    {
        private readonly IDbLandContext _context;
        public LandBeheer(IDbLandContext context)
        {
            _context = context;
        }

        public List<Land> AlleLandenUitDatabase()
        {
            List<Land> landen = new List<Land>();
            IEnumerable<LandDto> lds = new List<LandDto>();
            lds = _context.VraagAlleLandenOpUitDatabase();
            foreach (LandDto ld in lds)
            {
                landen.Add(new Land(ld.naam, ld.inwonersaantal, ld.straatbezetting, ld.doktersbezoeken));
            }
            return landen;
        }

        public Land VraagLandOp(string naam)
        {
            LandDto ld = _context.VraagLandOp(naam);
            Land land = new Land(ld.naam, ld.inwonersaantal, ld.straatbezetting, ld.doktersbezoeken);
            return land;

        }
    }
}
