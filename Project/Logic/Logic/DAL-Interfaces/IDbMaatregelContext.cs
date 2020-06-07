using Logic.DAL_Interfaces.Dto_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbMaatregelContext
    {
        public MaatregelDto MaatregelSelecteren(string naam, string niveau);
        public void MaatregelOpslaanInDatabase(MaatregelDto maatregel);
        public void MaatregelAanpassenInDatabase(MaatregelDto maatregel);
        public void MaatregelVerwijderenUitDatabase(MaatregelDto maatregel);
        public void MaatregelActiefInLandIntDatabaseOpslaan(MaatregelDto maatregel, LandDto land);
        public IEnumerable<MaatregelDto> VraagAlleMaatregelsOpVanNiveauUitDatabase(string niveau);
        public IEnumerable<MaatregelDto> VraagAlleMaatregelsOp();

    }
}
