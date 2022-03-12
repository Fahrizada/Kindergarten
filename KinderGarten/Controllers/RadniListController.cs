using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using KinderGarten.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace KinderGarten.Controllers
{
    [Authorize(Policy = "Zaposlenik")]
    public class RadniListController : Controller
    {
        private readonly IRadniListInterface radniListInterface;
        private readonly IGrupaInterface grupaInterface;
        private readonly IZaposlenikInterface zaposlenikInterface;
        private readonly INotificationService notificationService;

        public RadniListController(
            IRadniListInterface radniListInterface,
            IGrupaInterface grupaInterface,
            IZaposlenikInterface zaposlenikInterface,
            INotificationService notificationService
            )
        {
            this.radniListInterface = radniListInterface;
            this.grupaInterface = grupaInterface;
            this.zaposlenikInterface = zaposlenikInterface;
            this.notificationService = notificationService;
        }
        public IActionResult Index()
        {
            var lista = radniListInterface.GetAll();
            return View(lista);
        }
        public IActionResult AddRadniList()
        {
            List<SelectListItem> grupe = CreateSelectListItem(grupaInterface.GetAll());
            List<SelectListItem> zaposlenici = CreateSelectListItem(zaposlenikInterface.GetAll());

            DodajRadniListVM radniList = new DodajRadniListVM
            {
                Grupe = grupe,
                Zaposlenici = zaposlenici
            };
            return PartialView(radniList);
        }
        public IActionResult DetaljiRadniList(int RadniListID)
        {
            var edited = radniListInterface.GetAll()
                .Where(a => a.ID == RadniListID)
                .Select(a => new DetaljiRadniListVM
                {
                    GrupaID=a.GrupaID,
                    RadniListID = RadniListID,
                    Datum = a.Datum.ToShortDateString(),
                    Grupa = a.Grupa.Naziv,
                    Zaposlenik1 = $"{a.ZaposlenikPrvaSmjena.Ime} {a.ZaposlenikPrvaSmjena.Prezime}",
                    Zaposlenik2 = $"{a.ZaposlenikDrugaSmjena.Ime} {a.ZaposlenikDrugaSmjena.Prezime}"
                })
                .FirstOrDefault();
            return View(edited);
        }
        [HttpPost]
        public async Task<IActionResult> AddRadniList(DodajRadniListVM model)
        {
            await Task.Run(() =>
            {
                radniListInterface.AddRadniList(model);
                return Task.CompletedTask;
            });
            await notificationService.SendNotification($"Uspjesno dodan radni list za dan {DateTime.UtcNow.ToShortDateString()}");
            return RedirectToAction("Index");
        }
        private List<SelectListItem> CreateSelectListItem(List<Grupa> MyList)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in MyList)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Naziv });
            return sol;
        }
        private List<SelectListItem> CreateSelectListItem(List<Zaposlenik> MyList)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in MyList)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = $"{item.Ime} {item.Prezime}" });
            return sol;
        }
    }
}