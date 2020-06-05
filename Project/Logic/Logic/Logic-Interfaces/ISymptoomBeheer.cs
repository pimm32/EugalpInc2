using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface ISymptoomBeheer
    {
        public void SymptoomToevoegen(Symptoom symptoom);
        public void SymptoomAanpassen(Symptoom symptoom);
        public void SymptoomVerwijderen(Symptoom symptoom);
        public IEnumerable<Symptoom> AlleSymptomen();
        public IEnumerable<Symptoom> AlleSymptomenVanNiveau(Niveau niveau);
        public Symptoom OpvragenNaarNaam(string naam, string niveau);

    }
}
