using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tests
{
    [TestClass()]
    public class NiveauCollectieTests
    {
        protected NiveauCollectie NC = new NiveauCollectie();

        [TestMethod()]
        public void NiveauToevoegenSuccesvolTest()
        {
            Niveau niveau = new Niveau("makkelijk", 0.1, 0.1, 0.1);
            NC.NiveauToevoegen("makkelijk", 0.1, 0.1, 0.1);
            Niveau niveau2 = new Niveau("makkelijk", 0.1, 0.1, 0.1);

            // check of niveau en niveau2 gelijk zijn
        }

        [TestMethod()]
        public void NiveauToevoegenOnsuccesvolTest()
        {
            Niveau niveau = new Niveau("makkelijk", 0.1, 0.1, 0.1);
            NC.NiveauToevoegen("makkelijk", 0.1, 0.1, 0.1);
            Niveau niveau2 = new Niveau("gemiddeld", 0.1, 0.1, 0.1);

            // check of niveau en niveau 2 niet gelijk zijn
        }

        [TestMethod()]
        public void NiveauToevoegenOnsuccesvol2Test()
        {
            Niveau niveau = new Niveau("makkelijk", 0.1, 0.1, 0.1);
            NC.NiveauToevoegen("makkelijk", 0.1, 0.1, 0.1);
            Niveau niveau2 = new Niveau("0.1", 0.1, 0.1, 0.1);

            // check of ze gelijk zijn
        }

    }
}