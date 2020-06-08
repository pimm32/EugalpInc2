using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Logic_Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logic;
using Eugalp.Models.ViewModels;

namespace Eugalp.Controllers
{
    public class VirusController : Controller
    {
        private readonly INiveauBeheer _niveauContext;
        private readonly IVirusBeheer _virusContext;
        private readonly ILandBeheer _landContext;
        private readonly Virus _virus;

        public VirusController(INiveauBeheer niveauContext, IVirus virus, ILandBeheer landContext)
        {
            _virus = (Virus) virus;
            _niveauContext = niveauContext;
            _landContext = landContext;
        }

        public IActionResult EersteUitbraak()
        {
            VirusViewModel VVM = new VirusViewModel();
            VVM.naam = _virus.naam;
            VVM.besmettingsgraad = _virus.besmettingsgraad;
            VVM.herkenbaarheidsgraad = _virus.herkenbaarheidsgraad;
            VVM.sterftegraad = _virus.sterftegraad;
            VVM.aantalDagenSindsEersteUitbraak = _virus.aantalDagenSindsEersteUitbraak;
            List<LandViewModel> landen = new List<LandViewModel>(); 
            foreach (Land land in _landContext.AlleLandenUitDatabase())
            {
                landen.Add(new LandViewModel { naam = land.naam });
            }
            ViewData["landen"] = landen;
            ViewData["virus"] = VVM;
            return View(ViewBag);
        }
        [HttpPost]
        public IActionResult EersteUitbraak(string land)
        {
            _virus.VoegUitbraakToe(_landContext.VraagLandOp(land));

            return Redirect("Home");
        }
        [HttpPost]
        public IActionResult Start(VirusViewModel VVM)
        {
            
            //Niveau niveau = _niveauContext.SelecteerNiveau(Niveau);
            _virus.InitieerVirus(VVM.naam, VVM.besmettingsgraad, VVM.herkenbaarheidsgraad, VVM.sterftegraad, 0);
            return Redirect("EersteUitbraak");
        }
        [HttpGet]
        public IActionResult Start()
        {
            List<NiveauViewModel> niveaus = new List<NiveauViewModel>();
            foreach (Niveau niveau in _niveauContext.AlleNiveaus())
            {
                niveaus.Add(new NiveauViewModel { naam = niveau.naam, standaardBesmettingsgraad = niveau.standaardBesmettingsgraad, standaardHerkenbaarheidsgraad = niveau.standaardHerkenbaarheidsgraad, standaardSterftegraad = niveau.standaardSterftegraad });
            }
            ViewData["niveaus"] = niveaus;
            return View();
        }

        public IActionResult Home()
        {
            VirusViewModel VVM = new VirusViewModel();
            VVM.naam = _virus.naam;
            VVM.besmettingsgraad = _virus.besmettingsgraad;
            VVM.herkenbaarheidsgraad = _virus.herkenbaarheidsgraad;
            VVM.sterftegraad = _virus.sterftegraad;
            VVM.uitbraken = _virus.uitbraken;
            ViewData["virus"] = VVM;
            return View(ViewBag);
        }
    }
}
