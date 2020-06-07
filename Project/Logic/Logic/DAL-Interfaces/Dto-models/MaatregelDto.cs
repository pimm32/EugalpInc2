using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces.Dto_models
{
    public class MaatregelDto
    {
        public string naam { get; set; }
        public decimal straatbezettingFactor { get; set; }
        public decimal doktersbezoekenFactor { get; set; }
        public int ernst { get; set; }
        public decimal besmettingenGrens { get; set; }
        public decimal geregistreerdeBesmettingenGrens { get; set; }
        public decimal sterfteGrens { get; set; }
        public string categorie { get; set; }
        public string niveau { get; set; }

        public MaatregelDto(string naam, decimal sbf, decimal dbf, int ernst, decimal bG, decimal GbG, decimal SG, string niveau, string categorie )
        {
            this.naam = naam;
            this.straatbezettingFactor = sbf;
            this.doktersbezoekenFactor = dbf;
            this.ernst = ernst;
            this.besmettingenGrens = bG;
            this.geregistreerdeBesmettingenGrens = GbG;
            this.sterfteGrens = SG;
            this.niveau = niveau;
            this.categorie = categorie;
        }
        public MaatregelDto()
        {

        }
    }
}
