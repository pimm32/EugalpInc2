using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class MaatregelCategorie
    {
        public string naam { get; set; }
        public List<Maatregel> maatregels;

        public MaatregelCategorie()
        {
            maatregels = new List<Maatregel>();
        }

        public void MaatregelToevoegen(string naam, decimal sbf, decimal dbf, int ernst, decimal bg, decimal gbg, decimal sg)
        {
            Maatregel maatregel = new Maatregel(naam, sbf, dbf, ernst, bg, gbg, sg);
            this.maatregels.Add(maatregel);
        }
    }
}
