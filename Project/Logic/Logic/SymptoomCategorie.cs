using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class SymptoomCategorie
    {
        public string naam { get; set; }
        public List<Symptoom> symptomen;

        public SymptoomCategorie()
        {
            symptomen = new List<Symptoom>();
        }

        public void SymptoomToevoegen(string naam, decimal bgf, decimal hgf, decimal sgf, int ernst, int prijs)
        {
            Symptoom symptoom = new Symptoom(naam, bgf, hgf, sgf, ernst, prijs);
            this.symptomen.Add(symptoom);
        }
    }
}
