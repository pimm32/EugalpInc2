using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using Logic.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Logic
{
    public class VerbindingBeheer: IVerbindingBeheer
    {
        private readonly IDbVerbindingContext _context;
        private readonly IDbLandContext _landcontext;

        public VerbindingBeheer(IDbVerbindingContext context, IDbLandContext landcontext)
        {
            _context = context;
            _landcontext = landcontext;
        }

        public void VerbindingOpslaanInDatabase(Verbinding verbinding)
        {
            _context.VerbindingOpslaanInDatabase(new VerbindingDto(verbinding.vertrekLand.naam, verbinding.aankomstLand.naam, verbinding.mensenVerkeer));
        }

        public void VerbindingAanpassenInDatabase(Verbinding verbinding)
        {
            _context.VerbindingAanpassenInDatabase(new VerbindingDto(verbinding.vertrekLand.naam, verbinding.aankomstLand.naam, verbinding.mensenVerkeer));
        }

        public List<Verbinding> AlleVerbindingenVanLand(Land land)
        {
            List<Verbinding> resultaat = new List<Verbinding>();
            IEnumerable<VerbindingDto> vds = _context.VerbindingenVanLandOpvragen(land.naam);
            foreach (VerbindingDto vd in vds)
            {
                LandDto landIn = _landcontext.VraagLandOp(vd.aankomstLand);
                LandDto landUit = _landcontext.VraagLandOp(vd.vertrekLand);
                Verbinding verbinding = new Verbinding(new Land(landIn.naam, landIn.inwonersaantal, landIn.straatbezetting, landIn.doktersbezoeken), new Land(landUit.naam, landUit.inwonersaantal, landUit.straatbezetting, landUit.doktersbezoeken), vd.mensenVerkeer);
                resultaat.Add(verbinding);
            }
            return resultaat;
        }

        public List<Verbinding> AlleVerbindingen()
        {
            List<Verbinding> resultaat = new List<Verbinding>();
            IEnumerable<VerbindingDto> vds = _context.AlleVerbindingen();
            foreach (VerbindingDto vd in vds)
            {
                LandDto landIn = _landcontext.VraagLandOp(vd.aankomstLand);
                LandDto landUit = _landcontext.VraagLandOp(vd.vertrekLand);
                Verbinding verbinding = new Verbinding(new Land(landIn.naam, landIn.inwonersaantal, landIn.straatbezetting, landIn.doktersbezoeken), new Land(landUit.naam, landUit.inwonersaantal, landUit.straatbezetting, landUit.doktersbezoeken), vd.mensenVerkeer);
                resultaat.Add(verbinding);
            }
            return resultaat;
        }
    }
}
