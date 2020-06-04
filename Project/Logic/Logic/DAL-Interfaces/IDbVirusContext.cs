using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbVirusContext
    {
        public void VirusOpslaanInDatabase(Virus virus);
        public void VirusAanpassenInDatabase(Virus virus);
        public Virus VraagVirusOpInDatabase(string naam);
    }
}
