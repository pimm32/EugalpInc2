using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.Logic_Interfaces;

namespace Logic
{
    public class SymptoomCategorie: ISymptoomCategorie
    {
        public string naam { get; private set; }
        public List<Symptoom> symptomen;
        private readonly IDbSymptoomCategorieContext _context;

        public SymptoomCategorie(string naam)
        {
            symptomen = new List<Symptoom>();
        }

        public void SymptoomCategorieVullenMetDataUitDatabase()
        {
            //SymptoomCategorieBeheer SCB = new SymptoomCategorieBeheer();
        }

    }
}
