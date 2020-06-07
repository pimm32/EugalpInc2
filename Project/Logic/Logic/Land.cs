using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Logic
{
    public class Land: ILand
    {
        public string naam { get;  set; }
        public int inwonersaantal { get;  set; }
        public decimal straatbezetting { get;  set; }
        public decimal doktersbezoeken { get;  set; }
        
        public List<Maatregel> beschikbareMaatregels;
        public List<Verbinding> InkomendVerkeer { get; set; }
        public List<Verbinding> VertrekkendVerkeer { get; set; }

        public Land(string naam, int inwoners, decimal sb, decimal db)
        {
            this.naam = naam;
            this.inwonersaantal = inwoners;
            this.straatbezetting = sb;
            this.doktersbezoeken = db;
            beschikbareMaatregels = new List<Maatregel>();
            InkomendVerkeer = new List<Verbinding>();
            VertrekkendVerkeer = new List<Verbinding>();
        }
        public Land()
        {

        }
        //Hier wordt een land gevuld met alle maatregels en verbindingen (zie methodes hieronder)
        public void LandInitieren(List<Maatregel> maatregels, List<Verbinding> verbindingen)
        {
            MaatregelsToevoegen(maatregels);
            VerbindingenToevoegen(verbindingen);
        }
        //Hier worden alle maatregels toegevoegd waarover het land beschikt
        private void MaatregelsToevoegen(List<Maatregel> maatregels)
        {
            foreach(Maatregel maatregel in maatregels)
            {
                if (!BestaatMaatregelAlInLijst(maatregel))
                {
                    this.beschikbareMaatregels.Add(maatregel);
                }
            }
        }
        //Hier wordt gecontroleerd of een maatregel al in de lijst bestaat
        private bool BestaatMaatregelAlInLijst(Maatregel maatregel)
        {
            foreach (Maatregel maatregel1 in this.beschikbareMaatregels)
            {
                if(maatregel1.naam == maatregel.naam && maatregel1.niveau == maatregel.niveau)
                {
                    return true;
                }
            }
            return false;
        }
        //Hier worden alle inkomende en uitgaande verbindingen toegevoegd
        private void VerbindingenToevoegen(List<Verbinding> verbindingen)
        {
            this.VertrekkendVerkeer.Clear();
            this.InkomendVerkeer.Clear();
            foreach (Verbinding verbinding in verbindingen)
            {
                if(verbinding.aankomstLand.naam == verbinding.vertrekLand.naam)
                {
                    //throw error (maar dit kan helemaal niet voorkomen)
                }
                else if(verbinding.aankomstLand.naam == this.naam)
                {
                    if (!BestaatVerbindingAl(verbinding, "in"))
                    {
                        this.InkomendVerkeer.Add(verbinding);
                    }
                }
                else if(verbinding.vertrekLand.naam == this.naam)
                {
                    if(!BestaatVerbindingAl(verbinding, "uit"))
                    {
                        this.VertrekkendVerkeer.Add(verbinding);
                    }
                }
            }
        }
        
        //Hier wordt gecontroleerd of een verbinding al in de lijst bestaat, met parameter richting (in/uit)
        private bool BestaatVerbindingAl(Verbinding verbinding, string richting)
        {
            if(richting == "in")
            {
                foreach (Verbinding verbinding1 in this.InkomendVerkeer)
                {
                    if(verbinding1.aankomstLand.naam == verbinding.aankomstLand.naam && verbinding1.vertrekLand.naam == verbinding.vertrekLand.naam)
                    {
                        return true;
                    }
                }
            }
            if(richting == "uit")
            {
                foreach (Verbinding verbinding1 in this.VertrekkendVerkeer)
                {
                    if(verbinding1.vertrekLand.naam == verbinding.vertrekLand.naam && verbinding1.aankomstLand.naam == verbinding.vertrekLand.naam)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Hier wordt een land geupdate, het land controleert voor elke maatregel die niet actief 
        public void UpdateLand(int besmettingen, int geregistreerdeBesmettingen, int sterfgevallen)
        {
            foreach (Maatregel maatregel in beschikbareMaatregels)
            {
                if (!maatregel.actief)
                {
                    if(maatregel.MoetMaatregelGeactiveerdWorden(((decimal)besmettingen / (decimal)this.inwonersaantal), ((decimal)geregistreerdeBesmettingen / (decimal)this.inwonersaantal), ((decimal)sterfgevallen / (decimal)this.inwonersaantal)))
                    {
                        if (!HogereErnstMaatregelActief(maatregel))
                        {
                            ActiveerMaatregel(maatregel);
                        }
                    }
                }
            }
        }
        
        //Hier wordt gecontroleerd of er een maatregel van dezelfde categorie van dezelfde of hogere ernst actief is
        private bool HogereErnstMaatregelActief(Maatregel maatregel)
        {
            foreach (Maatregel maatregel1 in beschikbareMaatregels)
            {
                //Hier wordt gecontroleerd of de maatregel categorie gelijk is en de actieve maatregel een hogere ernst heeft
                if(maatregel1.categorie == maatregel.categorie && maatregel1.ernst > maatregel.ernst && maatregel1.actief)
                {
                    return true;
                }
            }
            return false;
        }
        //Hier wordt een enkele maatregel geactiveerd
        private void ActiveerMaatregel(Maatregel maatregel)
        {
            //Hier wordt de waarde van maatregel voor dit specifieke land geactiveerd, waardoor hij niet meer gechecked wordt
            //Of de maatregel geactiveerd dient te worden na een virus update
            foreach (Maatregel mtrl in this.beschikbareMaatregels)
            {
                //Hier controleer ik of de naam en het niveau van de maatregel overeenkomen (dit is een unieke combinatie voor maatregel)
                if (mtrl.naam == maatregel.naam && mtrl.niveau == maatregel.niveau)
                {
                    mtrl.MaatregelActiveren();
                    UpdateLand(mtrl.straatbezettingFactor, mtrl.doktersbezoekenFactor);
                }
                //Hier controleer ik of een maatregel actief is, van dezelfde categorie en een lagere ernst heeft
                //Als dat zo is wordt de maatregel gedeactiveerd en de waardes voor straatbezetting en doktersbezoeken geupdate
                else if (mtrl.categorie == maatregel.categorie && mtrl.ernst < maatregel.ernst && mtrl.actief)
                {
                    mtrl.MaatregelDeactiveren();
                    UpdateLand((1/mtrl.straatbezettingFactor),(1/ mtrl.doktersbezoekenFactor));
                }                    
            }
        }

        //Hier worden de waardes voor straatbezetting en doktersbezoeken geupdate na (de)activering van een maatregel
        private void UpdateLand(decimal sbFactor, decimal dbFactor)
        {
            this.straatbezetting *= sbFactor;
            this.doktersbezoeken *= dbFactor;
        }
    }
}
