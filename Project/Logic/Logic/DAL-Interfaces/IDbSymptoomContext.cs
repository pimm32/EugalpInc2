using Logic.DAL_Interfaces.Dto_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbSymptoomContext
    {
        public void SymptoomOpslaanInDatabase(SymptoomDto symptoom);
        public void SymptoomAanpassenInDatabase(SymptoomDto symptoom);
        public void SymptoomVerwijderenUitDatabase(SymptoomDto symptoom);
        public void SymptoomAanVirusToevoegenInDatabase(SymptoomDto symptoom, VirusDto virus);
        public IEnumerable<SymptoomDto> VraagAlleSymptomenOpVanCategorieVanNiveau(string niveau, string categorie);
        public IEnumerable<SymptoomDto> VraagAlleSymptomenOpVanVirus(VirusDto virus);
        public IEnumerable<SymptoomDto> VraagAlleSymptomenOp();
        public IEnumerable<SymptoomDto> VraagAlleSymptomenOpVanNiveau(string niveau);
        public SymptoomDto SymptoomSelecteren(string naam, string niveau);

    }
}
