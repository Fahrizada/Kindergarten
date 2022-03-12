using System.Collections.Generic;
using System.Linq;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using KinderGarten.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KinderGarten.Controllers
{
    public class GradController : Controller
    {
        private readonly IGradInterface _gradInterface;
        private readonly IDrzavaInterface _drzavaInterface;

        public GradController(IGradInterface gradInterface, IDrzavaInterface drzavaInterface)
        {
            _gradInterface = gradInterface;
            _drzavaInterface = drzavaInterface;
        }

        public IActionResult SeedDB() {

            string[] Drzave = { "Bosna i Hercegovina", "Srbija", "Hrvatska", "Crna Gora", "Njemacka" };

            foreach(var D in Drzave)
            {
                var dr = new Drzava
                {
                    Naziv = D
                };
                _drzavaInterface.AddDrzava(dr);
            }

            var drzava = _drzavaInterface.GetByName("Bosna i Hercegovina");

            string[] Gradovi = { "Tuzla", "Mostar", "Sarajevo", "Konjic", "Bihac", "Travnik", "Cazin", "Bugojno" };

            foreach(var G in Gradovi)
            {
                var grad = new Grad
                {
                    Drzava = drzava,
                    Naziv = G
                };

                _gradInterface.DodajGrad(grad);
            }

            return RedirectToAction("~/Home/Index");
        }

        public IActionResult Index()
        {
            var lista = _gradInterface.GetAll();
            return View("PrikazGradova", lista);
        }

        public IActionResult DodajGrad()
        {
            List<SelectListItem> drzave = CreateSelectListItem(_drzavaInterface.GetAll());

            DodajGradVM grad = new DodajGradVM
            {
                Drzave = drzave
            };
            return PartialView("DodajGrad", grad);
        }

        [HttpPost]
        public IActionResult DodajGrad(DodajGradVM model)
        {
            _gradInterface.AddGrad(model);
            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int GradID)
        {
            _gradInterface.DeleteGrad(GradID);
            return RedirectToAction("Index");
        }

        public IActionResult Izmijeni(int GradID)
        {
            var model = _gradInterface.GetAll().Where(x => x.ID == GradID).SingleOrDefault();

            List<SelectListItem> drzave = CreateSelectListItem(_drzavaInterface.GetAll());


            DodajGradVM editGrad = new DodajGradVM()
            {
                DrzavaID = model.DrzavaID,
                ID = model.ID,
                Naziv = model.Naziv,
                PostasnkiBroj = model.PostanskiBroj,
                Drzave = drzave
            };

            return PartialView("IzmijeniGrad", editGrad);
        }

        [HttpPost]
        public IActionResult Izmijeni(DodajGradVM model)
        {
            _gradInterface.SacuvajGrad(model);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> CreateSelectListItem(List<Drzava> MyList)
        {
            return MyList.OrderBy(x => x.Naziv).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Naziv
            }).ToList();
        }
    }
}