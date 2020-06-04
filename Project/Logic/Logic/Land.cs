using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Land
    {
        public string naam { get; private set; }
        public int inwonersaantal { get; private set; }
        public double straatbezetting { get; private set; }
        public double doktersbezoeken { get; private set; }
        public List<Maatregel> maatregels;

        public Land(string naam, int inwoners, double sb, double db)
        {
            this.naam = naam;
            this.inwonersaantal = inwoners;
            this.straatbezetting = sb;
            this.doktersbezoeken = db;
            maatregels = new List<Maatregel>();
        }

        public void MaatregelToevoegen(Maatregel maatregel)
        {
            this.maatregels.Add(maatregel);
        }

        //
        public void ActiveerMaatregel(Maatregel maatregel)
        {

        }
    }
}
