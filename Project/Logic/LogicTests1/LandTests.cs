using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Logic.Tests
{
    [TestClass()]
    public class LandTests
    {
        Land land, land2;

        Maatregel maatregel, maatregel2, maatregel3, maatregel4;
        Verbinding verbinding, verbinding2;
        List<Maatregel> maatregels;
        List<Verbinding> verbindingen;
        [TestInitialize]
        public void TestInitialize()
        {
            land = new Land("testland", 100, 0.01m, 0.01m);
            land2 = new Land("testland2", 50, 0.001m, 0.001m);
            maatregel = new Maatregel("test1", 1.1m, 1.1m, 2, 0.1m, 0.1m, 0.1m, "testcategorie", "testniveau");
            maatregel2 = new Maatregel("test2", 1.1m, 1.1m, 3, 0.2m, 0.2m, 0.2m, "testcategorie", "testniveau");
            maatregel3 = new Maatregel("test3", 1.1m, 1.1m, 4, 0.3m, 0.3m, 0.3m, "testcategorie", "testniveau");
            maatregel4 = new Maatregel("test4", 1.1m, 1.1m, 5, 0.4m, 0.4m, 0.4m, "testcategorie", "testniveau");
            verbinding = new Verbinding(land, land2, 20);
            verbinding2 = new Verbinding(land2, land, 5);
        }
        
        [TestMethod()]
        public void LandInitierenSuccesvol()
        {

            maatregels = new List<Maatregel> { maatregel, maatregel2, maatregel3, maatregel4 };
            verbindingen = new List<Verbinding> { verbinding, verbinding2 };
            land.LandInitieren(maatregels, verbindingen);

            Assert.AreEqual(land.beschikbareMaatregels.Count, 4);
            Assert.AreEqual(land.VertrekkendVerkeer.Count, 1);
            Assert.AreEqual(land.InkomendVerkeer.Count, 1);
        }

        [TestMethod()]
        public void LandUpdatenSuccesvol()
        {

            maatregels = new List<Maatregel> { maatregel, maatregel2, maatregel3, maatregel4 };
            verbindingen = new List<Verbinding> { verbinding, verbinding2 };
            land.LandInitieren(maatregels, verbindingen);
            land.UpdateLand(11, 1, 0);

            Assert.AreEqual(land.beschikbareMaatregels[0].actief, true);
        }

        [TestMethod()]
        public void MaatregelActiverenSuccesvol()
        {
            maatregels = new List<Maatregel> { maatregel };
            verbindingen = new List<Verbinding>();
            land.LandInitieren(maatregels, verbindingen);
            land.UpdateLand(10, 0, 0);

            Assert.AreEqual(land.beschikbareMaatregels[0].actief, true);
        }

        [TestMethod()]
        public void MaatregelNietActiverenNaUpdateSuccesvol()
        {
            maatregels = new List<Maatregel> { maatregel };
            verbindingen = new List<Verbinding>();
            land.LandInitieren(maatregels, verbindingen);
            land.UpdateLand(9, 0, 0);

            Assert.AreEqual(land.beschikbareMaatregels[0].actief, false);
        }

        [TestMethod()]
        public void MaatregelsDeactiverenNaAndereActivatie()
        {
            Maatregel maatregelx = new Maatregel("tester", 1.1m, 1.1m, 1, 0.1m, 0.1m, 0.1m, "testcategorie", "testniveau");
            maatregelx.actief = true;
            maatregels = new List<Maatregel> { maatregel, maatregelx };
            verbindingen = new List<Verbinding>();
            land.LandInitieren(maatregels, verbindingen);
            land.UpdateLand(10, 0, 0);
            Assert.AreEqual(land.beschikbareMaatregels.Count, 2);
            Assert.AreEqual(land.beschikbareMaatregels[0].actief, true);
            Assert.AreEqual(land.beschikbareMaatregels[1].actief, false);
            Assert.AreEqual(land.doktersbezoeken, 0.01m);
        }

        [TestMethod()]
        public void DubbeleMaatregelsToevoegenCheck()
        {
            maatregels = new List<Maatregel> { maatregel, maatregel2, maatregel };
            verbindingen = new List<Verbinding>();
            land.LandInitieren(maatregels, verbindingen);
            Assert.AreEqual(2, land.beschikbareMaatregels.Count);
        }


    }
}