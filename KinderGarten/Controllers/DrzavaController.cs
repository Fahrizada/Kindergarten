using System.Linq;
using KinderGarten.Models;
using KinderGarten.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinderGarten.Controllers
{
    public class DrzavaController : Controller
    {
        private readonly IDrzavaInterface _drzavaInterface;
        public DrzavaController(IDrzavaInterface drzavaInterface)
        {
            _drzavaInterface = drzavaInterface;
        }
        public IActionResult Index()
        {
            var lista = _drzavaInterface.GetAll();
            return View("PrikazDrzava", lista);
        }
        public IActionResult DodajDrzavu()
        {
            Drzava nova = new Drzava();
            return PartialView("DodajDrzavu", nova);
        }
        [HttpPost]
        public IActionResult DodajDrzavu(Drzava drzava)
        {
            _drzavaInterface.AddDrzava(drzava);
            return RedirectToAction("Index");
        }
        public IActionResult Obrisi(int DrzavaID)
        {
            _drzavaInterface.RemoveDrzava(DrzavaID);
            return RedirectToAction("Index");
        }
        public IActionResult Izmijeni(int DrzavaID)
        {
            var drzava = _drzavaInterface.GetAll().Where(x => x.ID == DrzavaID).SingleOrDefault();
            return PartialView("IzmijeniDrzavu", drzava);
        }
        [HttpPost]
        public IActionResult Izmijeni(Drzava drzava)
        {
            _drzavaInterface.SacuvajDrzavu(drzava);
            return RedirectToAction("Index");
        }
    }
}