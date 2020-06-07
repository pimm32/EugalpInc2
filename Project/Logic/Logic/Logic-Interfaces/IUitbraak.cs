using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface IUitbraak
    {
        public List<Land> BesmetteVerbondenLanden();
        public void UpdateUitbraak(decimal besmettingsgraad, decimal herkenbaarheidsgraad, decimal sterftegraad);

    }
}
