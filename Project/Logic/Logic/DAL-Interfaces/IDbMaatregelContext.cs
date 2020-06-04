using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbMaatregelContext
    {
        public void MaatregelOpslaanInDatabase(Maatregel maatregel);
        public void MaatregelAanpassenInDatabase(Maatregel maatregel);
        public void MaatregelVerwijderenUitDatabase(Maatregel maatregel);
        public void MaatregelActiefInLandIntDatabaseOpslaan(Maatregel maatregel, Land land);
        public IEnumerable<Maatregel> VraagAlleMaatregelsOpVanNiveauUitDatabase(Niveau niveau);

    }
}
