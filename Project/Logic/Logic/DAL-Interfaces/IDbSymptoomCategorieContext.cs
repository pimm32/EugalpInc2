using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbSymptoomCategorieContext
    {
        public IEnumerable<SymptoomCategorie> VraagAlleSymptoomCategorienOpUitDatabase();
    }
}
