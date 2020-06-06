using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tests
{
    [TestClass()]
    public class LandTests
    {
        
        [TestMethod()]
        public void LandInitierenSuccesvol()
        {
            Land land = new Land("testland", 100, 0.01m, 0.01m);
            Maatregel maatregel = new Maatregel("test1", 1.1m, 1.1m, 1, 0.1m, 0.1m, 0.1m, "testcategorie", "testniveau");
            Maatregel maatregel2 = new Maatregel("test2", 1.1m, 1.1m, 2, 0.2m, 0.2m, 0.2m, "testcategorie", "testniveau");
            Maatregel maatregel3 = new Maatregel("test3", 1.1m, 1.1m, 3, 0.3m, 0.3m, 0.3m, "testcategorie", "testniveau");
            Maatregel maatregel4 = new Maatregel("test4", 1.1m, 1.1m, 4, 0.4m, 0.4m, 0.4m, "testcategorie", "testniveau");
            List<Maatregel> maatregels = new List<Maatregel> { maatregel, maatregel2, maatregel3, maatregel4 };
            Land land2 = new Land("testland2", 50, 0.001m, 0.001m);
            Verbinding verbinding = new Verbinding(land, land2, 20);
            Verbinding verbinding2 = new Verbinding(land2, land, 5);
            List<Verbinding> verbindingen = new List<Verbinding> { verbinding, verbinding2 };
            land.LandInitieren(maatregels, verbindingen);

            Assert.AreEqual(land.beschikbareMaatregels.Count, 4);
            Assert.AreEqual(land.VertrekkendVerkeer.Count, 1);
            Assert.AreEqual(land.InkomendVerkeer.Count, 1);
        }
    }
}