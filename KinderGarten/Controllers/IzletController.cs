using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarten.Models;
using KinderGarten.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace KinderGarten.Controllers
{
    public class IzletController : Controller
    {
        private readonly IIzletInterface _izletInterface;
        private readonly IZaposlenikInterface _zaposlenikInterface;
        private readonly IDijeteIzletInterface _dijeteIzletInterface;
        private readonly IDjecaInterface _djecaInterface;
        private readonly IIzletZaposleniciInterface _IzletZaposleniciletInterface;

        public IzletController(IIzletInterface izletInterface, IZaposlenikInterface zaposlenikInterface, IDijeteIzletInterface dijeteIzletInterface, IDjecaInterface djecaInterface,
            IIzletZaposleniciInterface IzletZaposleniciletInterface)
        {
            _izletInterface = izletInterface;
            _zaposlenikInterface = zaposlenikInterface;
            _dijeteIzletInterface = dijeteIzletInterface;
            _djecaInterface = djecaInterface;
            _IzletZaposleniciletInterface = IzletZaposleniciletInterface;
        }

        public IActionResult Index(int? page)
        {

            var pageNumber = page ?? 1;
            int pageSize = 2;
            var OnePageOfIzlet = _izletInterface.GetAll().ToPagedList(pageNumber, pageSize);
            return View("Index", OnePageOfIzlet);
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajIzlet()
        {
            List<SelectListItem> zaposlenici = CreateSelectListItem(_zaposlenikInterface.GetAll());

            var model = new DodajIzletVM
            {
                Zaposlenici = zaposlenici
            };

            return PartialView("DodajIzlet", model);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajIzlet(DodajIzletVM model)
        {
            _izletInterface.Add(model);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalji(int IzletID)
        {

            var DjecaIzlet = new DjecaIzletVM
            {
                Izlet = _izletInterface.Find(IzletID),
                Djeca = _dijeteIzletInterface.GetByIzlet(IzletID),
                IzletZaposlenici = _IzletZaposleniciletInterface.GetByIzlet(IzletID)
            };

            return View(DjecaIzlet);
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajDjecu(int IzletID)
        {

            var SvaDjeca = CreateSelectListItem(_djecaInterface.GetAll());
            var DjecaNaIzletu = CreateSelectListItem(_dijeteIzletInterface.GetByIzlet(IzletID));

            var odsutnaDjeca = SvaDjeca;

            if (DjecaNaIzletu != null)
            {
                 odsutnaDjeca = SvaDjeca.Concat(DjecaNaIzletu)
                .GroupBy(x => x.Text)
                .Where(x => x.Count() == 1)
                .Select(x => x.FirstOrDefault())
                .ToList();
            }

            var djeca = new DodajDjecuNaIzletVM
            {
                Djeca = odsutnaDjeca,
                IzletID = IzletID
            };

            return PartialView(djeca);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajDjecu(int IzletID, DodajDjecuNaIzletVM model)
        {

            foreach(var i in model.DodavanjaIDs)
            {
                var dijete = new DijeteIzlet
                {
                    IzletID = IzletID,
                    DijeteID = i
                };

                _dijeteIzletInterface.Add(dijete);
            }

            return RedirectToAction(nameof(Detalji), new { IzletID });
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajZaposlenike(int IzletID)
        {
            var SviZaposlenici = CreateSelectListItem(_zaposlenikInterface.GetAll());
            var ZaposleniciNaIzletu = CreateSelectListItem(_IzletZaposleniciletInterface.GetByIzlet(IzletID));

            var OdsutniZaposlenici = SviZaposlenici;

            if (ZaposleniciNaIzletu != null)
            {
                OdsutniZaposlenici = SviZaposlenici.Concat(ZaposleniciNaIzletu)
               .GroupBy(x => x.Text)
               .Where(x => x.Count() == 1)
               .Select(x => x.FirstOrDefault())
               .ToList();
            }

            var zaposlenici = new DodajZaposlenikeIzletVM
            {
                Zaposlenici = OdsutniZaposlenici,
                IzletID = IzletID
            };

            return PartialView(zaposlenici);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajZaposlenike(int IzletID, DodajZaposlenikeIzletVM model)
        {
            foreach (var i in model.DodavanjaIDs)
            {
                var zaposlenik = new IzletZaposlenici
                {
                    IzletID = IzletID,
                    ZaposlenikID = i
                };

                _IzletZaposleniciletInterface.Add(zaposlenik);
            }

            return RedirectToAction(nameof(Detalji), new { IzletID });
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Izmijeni(int IzletID)
        {
            var izlet = _izletInterface.Find(IzletID);

            var zaposlenici = CreateSelectListItem(_zaposlenikInterface.GetAll());

            var model = new DodajIzletVM
            {
                DatumIzletaOd = izlet.DatumIzletaOd,
                DatumIzletaDo = izlet.DatumIzletaDo,
                IzletID = izlet.ID,
                Lokacija = izlet.Lokacija,
            };

            return PartialView(model);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Izmijeni(DodajIzletVM model)
        {
            _izletInterface.Update(model);

            return RedirectToAction(nameof(Detalji), new { IzletID = model.IzletID});
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Obrisi(int IzletID)
        {
            _izletInterface.Delete(IzletID);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult ObrisiDijete(int IzletID, int DijeteID)
        {
            _dijeteIzletInterface.Delete(IzletID, DijeteID);

            return RedirectToAction(nameof(Detalji), new { IzletID });
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult ObrisiZaposlenika(int IzletID, int ZaposlenikID)
        {
            _IzletZaposleniciletInterface.Delete(IzletID, ZaposlenikID);
            return RedirectToAction(nameof(Detalji), new { IzletID });
        }

        private List<SelectListItem> CreateSelectListItem(List<Zaposlenik> MyList)
        {
            return MyList.OrderBy(x => x.Ime).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();

     
        }
        private List<SelectListItem> CreateSelectListItem(List<Dijete> MyList)
        {
            return MyList.OrderBy(x => x.Ime).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();
        }
        private List<SelectListItem> CreateSelectListItem(List<IzletZaposlenici> MyList)
        {
            return MyList.OrderBy(x => x.Zaposlenik.Ime).Select(x => new SelectListItem
            {
                Value = x.ZaposlenikID.ToString(),
                Text = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime
            }).ToList();
        }

    }
}
