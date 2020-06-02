using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbVerbindingContext: DbContext
    {
        public void VerbindingOpslaanInDatabase()
        {
            throw new NotImplementedException();
        }

        public void VerbindingAanpassenInDatabase()
        {
            throw new NotImplementedException();
        }

        public void VerbindingVerwijderenUitDatabase()
        {
            throw new NotImplementedException();
        }

        public List<DalVerbinding> VraagInkomendeVerbindingenOpVanLand(string naam)
        {
            throw new NotImplementedException();
        }

        public List<DalVerbinding> VraagUitgaandeVerbindingenOpVanLand(string naam)
        {
            throw new NotImplementedException();
        }
    }
}
