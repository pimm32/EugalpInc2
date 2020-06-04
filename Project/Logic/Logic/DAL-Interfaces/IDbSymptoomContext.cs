using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbSymptoomContext
    {
        public void SymptoomOpslaanInDatabase(Symptoom symptoom);
        public void SymptoomAanpassenInDatabase(Symptoom symptoom);
        public void SymptoomVerwijderenUitDatabase(Symptoom symptoom);
        public void SymptoomAanVirusToevoegenInDatabase(Symptoom symptoom, Virus virus);
        public IEnumerable<Symptoom> VraagAlleSymptomenOpVanCategorieVanNiveau(Niveau niveau, SymptoomCategorie categorie);
        public IEnumerable<Symptoom> VraagAlleSymptomenOpVanVirus(Virus virus);
        public IEnumerable<Symptoom> VraagAlleSymptomenOp();
        public IEnumerable<Symptoom> VraagAlleSymptomenOpVanNiveau(Niveau niveau);
        public Symptoom SymptoomSelecteren(string naam);

    }
}
