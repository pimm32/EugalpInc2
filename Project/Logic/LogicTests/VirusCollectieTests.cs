using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Logic.Tests
{
    [TestClass()]
    public class VirusCollectieTests
    {
        VirusCollectie VC = new VirusCollectie();
        [TestMethod()]
        public void VirusSuccesvolToevoegenMetTekst()
        {
            Virus virus = new Virus("virus123", 0.1, 0.1, 0.1);
            Virus virus2 = new Virus("virus123", 0.1, 0.1, 0.1);
            VC.VirusToevoegen("virus123", 0.1, 0.5, 0.1);
            Virus expectedVirus = VC.HaalVirusOp("virus123");

            //assert virus en expectedVirus are equal
            Assert.IsTrue(compare(virus, virus2));
        }

        private bool compare(Virus a, Virus b)
        {

            var virusAprop = typeof(Virus).GetProperties();
            foreach (PropertyInfo PI in virusAprop)
            {
                //object? is een var die null mag zijn
                object? valueA = PI.GetValue(a);
                object? valueB = PI.GetValue(b);
                if (PI.PropertyType.Name == "double")
                {// als double afronden
                    valueA = Math.Round((double)PI.GetValue(a), 1);
                    valueB = Math.Round((double)PI.GetValue(b), 1);

                    
                   
                }

                if (valueA != valueB)
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod()]
        public void VirusSuccesvolToevoegenMetNiveau()
        {
            Niveau niveau = new Niveau("moeilijk", 0.1, 0.1, 0.1);
            Virus virus = new Virus("virus123", niveau);
            VC.VirusToevoegen("virus123", niveau.naam);
        }

        [TestMethod()]
        public void DubbelVirusOnsuccesvolToevoegen()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void VirusOnsuccesvolToevoegenMetOnbestaandNiveau()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void VirusSuccesvolLaden()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void VirusOnsuccesvolLadenGeenNaam()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void VirusOnsuccesvolLadenNietBestaandeNaam()
        {
            Assert.Fail();
        }

    }
}