using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tests
{
    [TestClass()]
    public class VirusTests
    {
        Virus virus;
        Niveau niveau;
        [TestInitialize]
        public void InitialisatieVanTesten()
        {
            niveau = new Niveau { naam = "makkelijk", standaardBesmettingsgraad = 1.1m, standaardHerkenbaarheidsgraad = 1.1m, standaardSterftegraad = 1.1m };
        }
        [TestMethod()]
        public void VirusInitierenMetNiveauTest()
        {
            virus = new Virus();
            Land land = new Land("test", 100, 0.1m, 0.1m);
            virus.VoegUitbraakToe(land);
            Assert.AreEqual(1, virus.uitbraken.Count);
        }
        [TestMethod()]
        public void VirusInitierenMetRauweDataTest()
        {
            throw new NotImplementedException();
        }
        [TestMethod()]
        public void VirusInitierenMetBestaandVirusTest()
        {
            throw new NotImplementedException();
        }
        [TestMethod()]
        public void VirusInitierenMetBestaandVirusTest2()
        {
            throw new NotImplementedException();
        }
        [TestMethod()]
        public void SymptoomToevoegenAanVirusTest()
        {
            throw new NotImplementedException();
           
        }
        [TestMethod()]
        public void DubbelSymptoomToevoegenAanVirusTest()
        {
            throw new NotImplementedException();

        }
        [TestMethod()]
        public void NietBestaandSymptoomToevoegenAanVirusTest()
        {
            throw new NotImplementedException();

        }
        //Deze testmethode controleert of hij de methodes (zie unit tests uitbraak) succesvol aanroept
        [TestMethod()]
        public void VirusUpdatenTest()
        {
            throw new NotImplementedException();

        }


    }
}