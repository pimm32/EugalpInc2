using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logic.Logic_Interfaces;
using Eugalp.Models.ViewModels;
using Logic;

namespace Eugalp.Controllers
{
    public class SymptoomController : Controller
    {
        private readonly ILogger<SymptoomController> _logger;
        private readonly ISymptoomBeheer _SymptoomBeheer;

        public SymptoomController(ILogger<SymptoomController> logger, ISymptoomBeheer SymptoomBeheer)
        {
            _SymptoomBeheer = SymptoomBeheer;
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inspecteer(string naam, string niveau)
        {
            SymptoomViewModel viewmodel = new SymptoomViewModel();
            
            Symptoom symptoom = _SymptoomBeheer.OpvragenNaarNaam(naam, niveau);
            viewmodel.naam = symptoom.naam;
            viewmodel.besmettingsgraadFactor = symptoom.besmettingsgraadFactor;
            viewmodel.herkenbaarheidsgraadFactor = symptoom.herkenbaarheidsgraadFactor;
            viewmodel.sterftegraadFactor = symptoom.sterftegraadFactor;
            viewmodel.ernst = symptoom.ernst;
            viewmodel.prijs = symptoom.prijs;
            viewmodel.niveau = symptoom.niveau;
            viewmodel.categorie = symptoom.categorie;
            return View(viewmodel);
        }
        public IActionResult Overview()
        {
            List<SymptoomViewModel> model = new List<SymptoomViewModel>();
            foreach(Symptoom symptoom in _SymptoomBeheer.AlleSymptomen())
            {
                SymptoomViewModel viewmodel = new SymptoomViewModel();
                viewmodel.naam = symptoom.naam;
                viewmodel.besmettingsgraadFactor = symptoom.besmettingsgraadFactor;
                viewmodel.herkenbaarheidsgraadFactor = symptoom.herkenbaarheidsgraadFactor;
                viewmodel.sterftegraadFactor = symptoom.sterftegraadFactor;
                viewmodel.ernst = symptoom.ernst;
                viewmodel.prijs = symptoom.prijs;
                viewmodel.niveau = symptoom.niveau;
                viewmodel.categorie = symptoom.categorie;
                model.Add(viewmodel);
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult SymptoomToevoegen(string naam, decimal bgf, decimal hgf, decimal sgf, int ernst, int prijs, string niveau, string categorie)
        {
            _SymptoomBeheer.SymptoomToevoegen(new Logic.Symptoom(naam, bgf, hgf, sgf, ernst, prijs, niveau, categorie));
            return RedirectToAction("Inspecteer", "Symptoom", naam);
        }
        [HttpDelete]
        public IActionResult SymptoomVerwijderen(string naam, string niveau)
        {
            _SymptoomBeheer.SymptoomVerwijderen(_SymptoomBeheer.OpvragenNaarNaam(naam, niveau));
            return RedirectToAction("Overview", "Symptoom");
        }
    }
}
