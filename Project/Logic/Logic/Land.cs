using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Land
    {
        public string naam { get;  set; }
        public int inwonersaantal { get;  set; }
        public decimal straatbezetting { get;  set; }
        public decimal doktersbezoeken { get;  set; }
        public List<Maatregel> maatregels;
        public List<Verbinding> InkomendVerkeer { get; set; }
        public List<Verbinding> VertrekkendVerkeer { get; set; }

        public Land(string naam, int inwoners, decimal sb, decimal db)
        {
            this.naam = naam;
            this.inwonersaantal = inwoners;
            this.straatbezetting = sb;
            this.doktersbezoeken = db;
            maatregels = new List<Maatregel>();
        }
        public Land()
        {

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
