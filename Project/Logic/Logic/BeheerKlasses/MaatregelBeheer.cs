using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class MaatregelBeheer: IMaatregelBeheer
    {
        private readonly IDbMaatregelContext _context;
        public MaatregelBeheer(IDbMaatregelContext context)
        {
            _context = context;
        }

        public Maatregel OpvragenNaarNaam(string naam, string niveau)
        {
            MaatregelDto md = _context.MaatregelSelecteren(naam, niveau);
            Maatregel maatregel = new Maatregel(md.naam, md.straatbezettingFactor, md.doktersbezoekenFactor, md.ernst, md.besmettingenGrens, md.geregistreerdeBesmettingenGrens, md.sterfteGrens, md.categorie, md.niveau);
            return maatregel;
        }

        public void MaatregelToevoegen(Maatregel maatregel)
        {
            MaatregelDto md = new MaatregelDto(maatregel.naam, maatregel.straatbezettingFactor, maatregel.doktersbezoekenFactor, maatregel.ernst, maatregel.besmettingenGrens, maatregel.geregistreerdeBesmettingenGrens, maatregel.sterfteGrens, maatregel.niveau, maatregel.categorie);
            _context.MaatregelOpslaanInDatabase(md);
        }

        public void MaatregelAanpassen(Maatregel maatregel)
        {
            MaatregelDto md = new MaatregelDto(maatregel.naam, maatregel.straatbezettingFactor, maatregel.doktersbezoekenFactor, maatregel.ernst, maatregel.besmettingenGrens, maatregel.geregistreerdeBesmettingenGrens, maatregel.sterfteGrens, maatregel.niveau, maatregel.categorie);
            _context.MaatregelAanpassenInDatabase(md);
        }

        public void MaatregelVerwijderen(Maatregel maatregel)
        {
            MaatregelDto md = new MaatregelDto(maatregel.naam, maatregel.straatbezettingFactor, maatregel.doktersbezoekenFactor, maatregel.ernst, maatregel.besmettingenGrens, maatregel.geregistreerdeBesmettingenGrens, maatregel.sterfteGrens, maatregel.niveau, maatregel.categorie);
            _context.MaatregelVerwijderenUitDatabase(md);
        }

        public IEnumerable<Maatregel> AlleMaatregels()
        {
            IEnumerable<MaatregelDto> mds = _context.VraagAlleMaatregelsOp();
            List<Maatregel> maatregels = new List<Maatregel>();
            foreach (MaatregelDto md in mds)
            {
                Maatregel maatregel = new Maatregel(md.naam, md.straatbezettingFactor, md.doktersbezoekenFactor, md.ernst, md.besmettingenGrens, md.geregistreerdeBesmettingenGrens, md.sterfteGrens, md.categorie, md.niveau);
                maatregels.Add(maatregel);
            }
            return maatregels;
        }

        public IEnumerable<Maatregel> AlleMaatregelsVanNiveau(string niveau)
        {
            IEnumerable<MaatregelDto> mds = _context.VraagAlleMaatregelsOpVanNiveauUitDatabase(niveau);
            List<Maatregel> maatregels = new List<Maatregel>();
            foreach (MaatregelDto md in mds)
            {
                Maatregel maatregel = new Maatregel(md.naam, md.straatbezettingFactor, md.doktersbezoekenFactor, md.ernst, md.besmettingenGrens, md.geregistreerdeBesmettingenGrens, md.sterfteGrens, md.categorie, md.niveau);
                maatregels.Add(maatregel);
            }
            return maatregels;
        }
    }
}
