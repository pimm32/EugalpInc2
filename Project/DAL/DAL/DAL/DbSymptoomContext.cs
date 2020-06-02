using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbSymptoomContext: DbContext
    {
        public void SymptoomOpslaanInDatabase()
        {
            throw new NotImplementedException();
        }

        public void SymptoomAanpassenInDatabase()
        {
            throw new NotImplementedException();
        }
        public void SymptoomVerwijderenUitDatabase()
        {
            throw new NotImplementedException();
        }
        public List<DalSymptoom> VraagAlleSymptomenOpVanNiveau()
        {
            throw new NotImplementedException();
        }

        public List<DalSymptoom> VraagAlleSymptomenOpVanVirus()
        {
            throw new NotImplementedException();
        }
    }
}
