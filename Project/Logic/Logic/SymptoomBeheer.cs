using Logic.DAL_Interfaces;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class SymptoomBeheer: ISymptoomBeheer
    {
        private readonly IDbSymptoomContext _context;

        public SymptoomBeheer(IDbSymptoomContext context)
        {
            _context = context;
        }

        public Symptoom OpvragenNaarNaam(string naam, string niveau)
        {
            
            return _context.SymptoomSelecteren(naam, niveau);
        }

        public void SymptoomToevoegen(Symptoom symptoom)
        {
            _context.SymptoomOpslaanInDatabase(symptoom);
        }

        public void SymptoomAanpassen(Symptoom symptoom)
        {
            _context.SymptoomAanpassenInDatabase(symptoom);
        }

        public void SymptoomVerwijderen(Symptoom symptoom)
        {
            _context.SymptoomVerwijderenUitDatabase(symptoom);
        }

        public IEnumerable<Symptoom> AlleSymptomen()
        {
            return _context.VraagAlleSymptomenOp();
        }

        public IEnumerable<Symptoom> AlleSymptomenVanNiveau(Niveau niveau)
        {
            return _context.VraagAlleSymptomenOpVanNiveau(niveau);
        }

    }
}
