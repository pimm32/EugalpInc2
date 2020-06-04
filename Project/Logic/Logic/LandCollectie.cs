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

        public void VoegLandToe(string naam, int inwoners, double sb, double db)
        {
            Land land = new Land(naam, inwoners, sb, db);
            this.landen.Add(land);
        }


    }
}
