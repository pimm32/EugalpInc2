using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Logic.Tests
{
    [TestClass()]
    public class UitbraakTests
    {
        Land land, land2;

        Maatregel maatregel, maatregel2, maatregel3, maatregel4;
        Verbinding verbinding, verbinding2;
        List<Maatregel> maatregels;
        List<Verbinding> verbindingen;
        Uitbraak uitbraak;
        [TestInitialize]
        public void Initialisatie()
        {
            land = new Land("testland", 100, 0.01m, 0.01m);
            land2 = new Land("testland2", 50, 0.001m, 0.001m);
            maatregel = new Maatregel("test1", 1.1m, 1.1m, 2, 0.1m, 0.1m, 0.1m, "testcategorie", "testniveau");
            maatregel2 = new Maatregel("test2", 1.1m, 1.1m, 3, 0.2m, 0.2m, 0.2m, "testcategorie", "testniveau");
            maatregel3 = new Maatregel("test3", 1.1m, 1.1m, 4, 0.3m, 0.3m, 0.3m, "testcategorie", "testniveau");
            maatregel4 = new Maatregel("test4", 1.1m, 1.1m, 5, 0.4m, 0.4m, 0.4m, "testcategorie", "testniveau");
            verbinding = new Verbinding(land, land2, 20);
            verbinding2 = new Verbinding(land2, land, 5);
            maatregels = new List<Maatregel> { maatregel, maatregel2, maatregel3, maatregel4 };
            verbindingen = new List<Verbinding> { verbinding, verbinding2 };
            land.LandInitieren(maatregels, verbindingen);
        }
        [TestMethod()]
        public void UitbraakConstructorTest()
        {
            uitbraak = new Uitbraak(land);
            Assert.AreEqual(uitbraak.land.naam, land.naam);
            Assert.AreEqual(uitbraak.aantalBesmettingen, 1);
        }
        [TestMethod()]
        public void UpdateUitbraakTest()
        {
            uitbraak = new Uitbraak(land);
            uitbraak.UpdateUitbraak(5m, 1.1m, 1.1m);
            Assert.AreEqual(uitbraak.aantalBesmettingen, 6);
        }
        [TestMethod()]
        public void BesmetteVerbondenLandenTest()
        {
            uitbraak = new Uitbraak(land);
            uitbraak.UpdateUitbraak(5m, 1.1m, 1.1m);
            Assert.AreEqual(uitbraak.BesmetteVerbondenLanden().Count, 1);
        }
        [TestMethod()]
        public void BesmetteVerbondenLandenTestAssertFail()
        {
            uitbraak = new Uitbraak(land);
            uitbraak.UpdateUitbraak(2m, 1.1m, 1.1m);
            Assert.AreNotEqual(uitbraak.BesmetteVerbondenLanden().Count, 1);
        }
    }
}