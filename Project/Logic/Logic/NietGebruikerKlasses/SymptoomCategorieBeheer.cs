using Logic.DAL_Interfaces;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class SymptoomCategorieBeheer: ISymptoomCategorieBeheer
    {
        private readonly IDbSymptoomCategorieContext _context;
        public SymptoomCategorieBeheer(IDbSymptoomCategorieContext context)
        {
            _context = context;
        }

        public IEnumerable<SymptoomCategorie> AlleCategorien()
        {
            return _context.VraagAlleSymptoomCategorienOpUitDatabase();
        }
    }
}
