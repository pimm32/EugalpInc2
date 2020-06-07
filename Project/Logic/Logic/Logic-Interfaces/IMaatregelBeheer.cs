using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface IMaatregelBeheer
    {
        public Maatregel OpvragenNaarNaam(string naam, string niveau);
        public void MaatregelToevoegen(Maatregel maatregel);
        public void MaatregelAanpassen(Maatregel maatregel);
        public void MaatregelVerwijderen(Maatregel maatregel);
        public IEnumerable<Maatregel> AlleMaatregels();
        public IEnumerable<Maatregel> AlleMaatregelsVanNiveau(string niveau);

    }
}
