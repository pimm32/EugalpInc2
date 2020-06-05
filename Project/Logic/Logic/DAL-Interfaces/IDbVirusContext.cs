using Logic.DAL_Interfaces.Dto_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbVirusContext
    {
        public void VirusOpslaanInDatabase(VirusDto virus);
        public void VirusAanpassenInDatabase(VirusDto virus);
        public VirusDto VraagVirusOpInDatabase(string naam);
    }
}
