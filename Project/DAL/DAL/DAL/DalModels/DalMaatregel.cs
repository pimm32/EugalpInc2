using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DalModels
{
    public class DalMaatregel
    {
        public string naam { get; set; }
        public decimal straatbezettingFactor { get; set; }
        public decimal doktersbezoekenFactor { get; set; }
        public int ernst { get; set; }
        public decimal besmettingenGrens { get; set; }
        public decimal geregistreerdeBesmettingenGrens { get; set; }
        public decimal sterfteGrens { get; set; }
    }
}
