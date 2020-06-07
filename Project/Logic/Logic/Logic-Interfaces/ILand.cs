using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface ILand
    {
        public void LandInitieren(List<Maatregel> maatregels, List<Verbinding> verbindingen);
        public void UpdateLand(int besmettingen, int geregistreerdeBesmettingen, int sterfgevallen);
    }
}
