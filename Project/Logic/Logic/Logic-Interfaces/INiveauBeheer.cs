using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Logic_Interfaces
{
    public interface INiveauBeheer
    {
        public Niveau SelecteerNiveau(string naam);
        public List<Niveau> AlleNiveaus();
    }
}
