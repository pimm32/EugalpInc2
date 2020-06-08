using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface IVirus
    {
        public void InitieerVirus(string naam, decimal bg, decimal hg, decimal sg, List<Symptoom> symptomen);
        public void InitieerVirus(string naam, decimal bg, decimal hg, decimal sg, int dagen);
        public void InitieerVirus(string naam, Niveau niveau);
        public void SymptoomActiveren(Symptoom symptoom);
        public void UpdateVirus(List<Land> landen);
        public void VoegUitbraakToe(Land land);

    }
}
