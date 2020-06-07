using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface IVirusBeheer
    {
        public Virus HaalVirusOpUitDatabaseBijNaam(string naam);
        public void SlaVirusOpInDatabase(Virus virus);
    }
}

