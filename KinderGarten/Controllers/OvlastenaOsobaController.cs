using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using KinderGarten.Helper;
using KinderGarten.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace KinderGarten.Controllers
{
    [Authorize(Policy = "Admin")]
    public class OvlastenaOsobaController : Controller
    {
        private readonly IOvlastenaOsobaInterface _ovlastenaOsobaInterface;
        private readonly IStrucnaSpremaInterface _strucnaSpremaInterface;
        public OvlastenaOsobaController(IOvlastenaOsobaInterface ovlastenaOsobaInterface,
                                        IStrucnaSpremaInterface strucnaSpremaInterface)
        {
            _ovlastenaOsobaInterface = ovlastenaOsobaInterface;
            _strucnaSpremaInterface = strucnaSpremaInterface;
        }
        public IActionResult Index()
        {
            var lista = _ovlastenaOsobaInterface.GetAll();
            return View("PrikazOvlastenihOsoba",lista);
        }
        public IActionResult DodajOvlastenaOsoba(int DijeteID)
        {
            ViewData["dijeteId"] = DijeteID;

            List<SelectListItem> strSprema = CreateSelectListItem(_strucnaSpremaInterface.GetAll());

            DodajOvlastenuOsobuVM osoba = new DodajOvlastenuOsobuVM();
            osoba.StrucnaSprema = strSprema;
            return PartialView("DodajOvlastenuOsobu", osoba);
        }

        [HttpPost]
        public IActionResult DodajOvlastenaOsoba(DodajOvlastenuOsobuVM modal, IFormFile slika = null)
        {
            _ovlastenaOsobaInterface.AddOvlastenaOsoba(modal,slika);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> CreateSelectListItem(List<StrucnaSprema> list)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in list)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Naziv });
            return sol;
        }
        public IActionResult ObrisiOvlastenaOsoba(int OvlastenaOsobaID)
        {
            _ovlastenaOsobaInterface.ObrisiOvlastenaOsoba(OvlastenaOsobaID);
            return RedirectToAction("Index");
        }
        public IActionResult Izmijeni(int OvlastenaOsobaID)
        {
            var model = _ovlastenaOsobaInterface.GetAll().Where(x => x.ID == OvlastenaOsobaID).SingleOrDefault();

            List<SelectListItem> strSprema = CreateSelectListItem(_strucnaSpremaInterface.GetAll());


            DodajOvlastenuOsobuVM edit = new DodajOvlastenuOsobuVM()
            {
                StrucnaSpremaID = model.StrucnaSpremaID,
                ID = model.ID,
                JMBG = model.JMBG,
                Ime = model.Ime,
                Prezime = model.Prezime,
                DatumRodjenja = model.DatumRodjenja,
                Adresa = model.Adresa,
                BrojTelefona = model.BrojTelefona,
                Email = model.Email,
                StrucnaSprema = strSprema
            };

            return PartialView("IzmijeniOvlastenuOsobu", edit);
        }

        [HttpPost]
        public IActionResult Izmijeni(DodajOvlastenuOsobuVM model)
        {
            _ovlastenaOsobaInterface.SacuvajOvlastenaOsoba(model);
            return RedirectToAction("Index");
        }
        public IActionResult Detalji(int OvlastenaOsobaID)
        {
            var dijete = _ovlastenaOsobaInterface.GetAll().Where(x => x.ID == OvlastenaOsobaID).FirstOrDefault();
            return View("DetaljiOvlasteneOsobe", dijete);
        }
        [HttpPost]
        public async Task<IActionResult> SpremiSliku([FromForm]IFormFile file, [FromQuery]int OvlastenaOsoba)
        {
            string path = await ImageUpload.Upload(file);
            _ovlastenaOsobaInterface.IzmijeniSliku(OvlastenaOsoba, path);
            return RedirectToAction(nameof(Index));
        }
    }
}