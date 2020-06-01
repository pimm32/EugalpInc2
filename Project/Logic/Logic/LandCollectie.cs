using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class LandCollectie
    {
        public List<Land> landen;

        public LandCollectie()
        {
            landen = new List<Land>();
        }

        public void VoegLandToe(string naam, int inwoners, decimal sb, decimal db)
        {
            Land land = new Land(naam, inwoners, sb, db);
            this.landen.Add(land);
        }


    }
}
