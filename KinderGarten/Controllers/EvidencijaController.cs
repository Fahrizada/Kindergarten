using System.Linq;
using KinderGarten.ViewModels;
using KinderGarten.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KinderGarten.Controllers
{
    public class EvidencijaController : Controller
    {
        private readonly IEvidencijeService evidencijeService;
        private readonly IRadniListInterface radniListInterface;
        private readonly IDjecaInterface djecaInterface;
        private readonly IZaposlenikInterface zaposlenikInterface;
        private readonly IRoditeljInterface roditeljInterface;

        public EvidencijaController(IEvidencijeService evidencijeService,
            IRadniListInterface radniListInterface,
            IDjecaInterface djecaInterface,
            IZaposlenikInterface zaposlenikInterface,
           IRoditeljInterface roditeljInterface
            )
        {
            this.evidencijeService = evidencijeService;
            this.radniListInterface = radniListInterface;
            this.djecaInterface = djecaInterface;
            this.zaposlenikInterface = zaposlenikInterface;
            this.roditeljInterface= roditeljInterface;
        }
        public IActionResult Index(int? RadniListID)
        {
            if (RadniListID.HasValue)
            {
                return PartialView(evidencijeService.GetAll().Where(x => x.RadniListID == RadniListID).ToList());
            }
            return View(evidencijeService.GetAll());
        }
        [HttpGet]
        public IActionResult DodajEvidenciju(int RadniListId)
        {
            var djeca = djecaInterface.GetAll().Select(a => new SelectListItem()
            {
                Text = $"{a.Ime} {a.Prezime}",
                Value = a.ID.ToString()
            }).ToList();
            var zaposlenici = zaposlenikInterface.GetAll().Select(a => new SelectListItem()
            {
                Text = $"{a.Ime} {a.Prezime}",
                Value = a.ID.ToString()
            }).ToList();
            var roditelji = roditeljInterface.GetAll().Select(a => new SelectListItem()
            {
                Text = $"{a.Ime} {a.Prezime}",
                Value = a.ID.ToString()
            }).ToList();

            var model = new DodajEvidencijuVM
            {
                Djeca = djeca,
                Zaposlenici = zaposlenici,
                Roditelji = roditelji,
                RadniListID = RadniListId
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult DodajEvidenciju(DodajEvidencijuVM model)
        {
            evidencijeService.DodajEvidenciju(model);
            return RedirectToAction("Index", "RadniList");
        }
        public IActionResult DjecaGrupa(int GrupaID)
        {
            var lista = djecaInterface.GetAll()
                .Where(a => a.GrupaID == GrupaID)
                .Select(a => new DjecaGrupaVM
                {
                    DijeteID = a.ID,
                    DijeteImePrezime = $"{a.Ime} {a.Prezime}",
                    Dolazak = evidencijeService.GetAll().Where(x => x.DijeteID == a.ID).OrderByDescending(s => s.ID).FirstOrDefault()?.Odlazak
                })
                .ToList();

            return PartialView(lista);
        }
        public IActionResult PromijeniStatus(int EvidencijaID)
        {
            evidencijeService.PromijeniStatus(EvidencijaID);
            var evidencija = evidencijeService.GetAll().FirstOrDefault(x => x.ID == EvidencijaID);
            return RedirectToAction(nameof(Index), new { evidencija.RadniListID });
        }
    }
}