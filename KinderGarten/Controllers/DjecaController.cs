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
    public class DjecaController : Controller
    {
        private readonly IDjecaInterface _djecaInterface;
        private readonly IGrupaInterface _grupaInterface;
        private readonly IOvlastenaOsobaInterface _ovlastenaOsobaInterface;
        private readonly IRoditeljInterface _roditeljInterface;

        public DjecaController(IDjecaInterface djecaInterface,
            IGrupaInterface grupaInterface, 
            IOvlastenaOsobaInterface ovlastenaOsobaInterface,
            IRoditeljInterface roditeljInterface)
        {
            _djecaInterface = djecaInterface;
            _grupaInterface = grupaInterface;
            _ovlastenaOsobaInterface = ovlastenaOsobaInterface;
            _roditeljInterface = roditeljInterface;

        }
        public IActionResult Index()
        {
            var lista = _djecaInterface.GetAll();
            return View("PrikazDjece",lista);
        }
        public IActionResult DodajDijete()
        {
            List<SelectListItem> grupe = CreateSelectListItem(_grupaInterface.GetAll());
            List<SelectListItem> roditelji = CreateSelectListItem(_roditeljInterface.GetAll());


            DodajDijeteVM dijete = new DodajDijeteVM();
            dijete.Grupe = grupe;
            dijete.Roditelj = roditelji;
           
            return PartialView("DodajDijete", dijete);
        }

        [HttpPost]
        public IActionResult DodajDijete(DodajDijeteVM model, IFormFile slika = null)
        {
            //var dijeteID = _djecaInterface.AddDijete(model, slika);
            //return RedirectToAction("Detalji", dijeteID);
            _djecaInterface.AddDijete(model, slika);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> CreateSelectListItem(List<Grupa> MyList)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in MyList)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Naziv });
            return sol;
        }
        
        private List<SelectListItem> CreateSelectListItem(List<Roditelj> MyList)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in MyList)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Ime + " " + item.Prezime });
            return sol;
        }
        public IActionResult ObrisiDijete(int DijeteID)
        {
            _djecaInterface.ObrisiDijete(DijeteID);
            return RedirectToAction("Index");
        }
        public IActionResult Izmijeni(int DijeteID)
        {
            var model = _djecaInterface.GetAll().Where(x => x.ID == DijeteID).SingleOrDefault();

            List<SelectListItem> grupe = CreateSelectListItem(_grupaInterface.GetAll());


            DodajDijeteVM editDijete = new DodajDijeteVM()
            {
                GrupaID = model.GrupaID,
                ID = model.ID,
                Ime = model.Ime,
                Prezime = model.Prezime,
                JMBG = model.JMBG,
                DatumRodjenja = model.DatumRodjenja,
                Napomena = model.Napomena,
                PosebnePotrebe = model.PosebnePotrebe,
                Grupe = grupe
            };

            return PartialView("IzmijeniDijete", editDijete);
        }
        [HttpPost]
        public IActionResult Izmijeni(DodajDijeteVM model)
        {
            _djecaInterface.SacuvajDijete(model);
            return RedirectToAction("Index");
        }
        public IActionResult Detalji(int DijeteID)
        {
            var dijete = _djecaInterface.GetAll().Where(x => x.ID == DijeteID).FirstOrDefault();
            
            DijeteOvlastenaOsobaVM model = new DijeteOvlastenaOsobaVM();
            model.Dijete = dijete;
            model.OvlastenaOsoba = _ovlastenaOsobaInterface.GetByDijeteID(DijeteID);


            return View("DetaljiDjeteta", model);
        }

        [HttpPost]
        public async Task<IActionResult> SpremiSliku([FromForm]IFormFile file, [FromQuery]int Dijete)
        {
            string path = await ImageUpload.Upload(file);
            _djecaInterface.IzmijeniSliku(Dijete, path);
            return RedirectToAction(nameof(Index));
        }
    }
}