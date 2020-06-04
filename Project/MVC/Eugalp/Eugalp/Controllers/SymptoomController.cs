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

        public IActionResult Inspecteer(string naam)
        {
            SymptoomViewModel viewmodel = new SymptoomViewModel();
            Symptoom symptoom = new Symptoom(_SymptoomBeheer.)
            return View();
        }
        [HttpPost]
        public IActionResult SymptoomToevoegen(string naam, decimal bgf, decimal hgf, decimal sgf, int ernst, int prijs)
        {
            _SymptoomBeheer.SymptoomToevoegen(new Logic.Symptoom(naam, bgf, hgf, sgf, ernst, prijs));
            return RedirectToAction("Inspecteer", "Symptoom", naam);
        }
    }
}
