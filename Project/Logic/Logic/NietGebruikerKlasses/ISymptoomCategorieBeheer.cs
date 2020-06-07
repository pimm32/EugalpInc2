using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface ISymptoomCategorieBeheer
    {
        public IEnumerable<SymptoomCategorie> AlleCategorien();
    }
}
