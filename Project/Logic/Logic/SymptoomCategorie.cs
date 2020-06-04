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

        public void SymptoomToevoegen(string naam, double bgf, double hgf, double sgf, int ernst, int prijs)
        {
            Symptoom symptoom = new Symptoom(naam, bgf, hgf, sgf, ernst, prijs);
            this.symptomen.Add(symptoom);
        }
    }
}
