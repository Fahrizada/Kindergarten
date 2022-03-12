using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarten.Helper;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace KinderGarten.Controllers
{
    public class AktivnostController : Controller
    {
        private readonly IAktivnostInterface _aktivnostInterface;
        private readonly IZaposlenikInterface _zaposleniktInterface;
        private readonly IDijeteAktivnostInterface _dijeteAktivnostInterface;
        private readonly IZaposlenikAktivnostInterface _zaposlenikAktivnostInterface;
        private readonly IDjecaInterface _djecaInterface;

        public AktivnostController(IAktivnostInterface aktivnostInterface, IZaposlenikInterface zaposleniktInterface,
            IDijeteAktivnostInterface dijeteAktivnostInterface,
            IZaposlenikAktivnostInterface zaposlenikAktivnostInterface,
            IDjecaInterface djecaInterface)
        {
            _aktivnostInterface = aktivnostInterface;
            _zaposleniktInterface = zaposleniktInterface;
            _dijeteAktivnostInterface = dijeteAktivnostInterface;
            _zaposlenikAktivnostInterface = zaposlenikAktivnostInterface;
            _djecaInterface=djecaInterface;
        }

        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 2;
            var OnePageOfAktivnost = _aktivnostInterface.GetAll().ToPagedList(pageNumber, pageSize);
            return View("PrikazAktivnosti", OnePageOfAktivnost);
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajAktivnost()
        {
            Aktivnost aktivnost=new Aktivnost();
            return View("DodajAktivnost", aktivnost);
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        [HttpPost]
        public IActionResult DodajAktivnost(Aktivnost model)
        {
            _aktivnostInterface.Add(model);
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult ObrisiAktivnost(int AktivnostID)
        {
            _aktivnostInterface.Delete(AktivnostID);
            return RedirectToAction("Index");
        }
        public IActionResult DetaljiAktivnosti(int AktivnostID)
        {
            var A = new AktivnostDjecaZaposleniVM
            {
                Aktivnost = _aktivnostInterface.Find(AktivnostID),
                Djeca= _djecaInterface.GetAll(),
                DjecaAktivnost =_dijeteAktivnostInterface.GetByAktivnost(AktivnostID),
                ZaposlenikAktivnost = _zaposlenikAktivnostInterface.GetByAktivnost(AktivnostID),
                Zaposlenik=_zaposleniktInterface.GetAll()
            };

            return View("DetaljiAktivnosti",A);
            
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajDjecu(int AktivnostID)
        {
            var SvaDjeca = CreateSelectListItem(_djecaInterface.GetAll());
            var DjecaNaAktivnosti = CreateSelectListItem(_dijeteAktivnostInterface.GetByAktivnost(AktivnostID));

            var odsutnaDjeca = SvaDjeca;

            if (DjecaNaAktivnosti != null)
            {
                odsutnaDjeca = SvaDjeca.Concat(DjecaNaAktivnosti)
               .GroupBy(x => x.Text)
               .Where(x => x.Count() == 1)
               .Select(x => x.FirstOrDefault())
               .ToList();
            }

            var djeca = new DodajDjecuNaAktivnost
            {
                Djeca = odsutnaDjeca,
                AktivnostID = AktivnostID
            };

            return PartialView(djeca);
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        [HttpPost]
        public IActionResult DodajDjecu(int AktivnostID, DodajDjecuNaIzletVM model)
        {

            foreach (var i in model.DodavanjaIDs)
            {
                var dijete = new DijeteAktivnost
                {
                    AktivnostID = AktivnostID,
                    DijeteID = i
                };

                _dijeteAktivnostInterface.Add(dijete);
            }

            return RedirectToAction("DetaljiAktivnosti", new { AktivnostID });
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajZaposlenika(int AktivnostID)
        {
            var SviZaposleni = CreateSelectListItem(_zaposleniktInterface.GetAll());
            var ZaposleniNaAktivnosti = CreateSelectListItem(_zaposlenikAktivnostInterface.GetByAktivnost(AktivnostID));

            var odsutniZaposlenici = SviZaposleni;

            if (ZaposleniNaAktivnosti != null)
            {
                odsutniZaposlenici = SviZaposleni.Concat(ZaposleniNaAktivnosti)
               .GroupBy(x => x.Text)
               .Where(x => x.Count() == 1)
               .Select(x => x.FirstOrDefault())
               .ToList();
            }

            var zaposleni = new DodajZaposleneNaAktivnost
            {
                Zaposlenik = odsutniZaposlenici,
                AktivnostID = AktivnostID
            };

            return PartialView(zaposleni);
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        [HttpPost]
        public IActionResult DodajZaposlenika(int AktivnostID, DodajZaposleneNaAktivnost model)
        {

            foreach (var i in model.DodavanjaIDs)
            {
                var zaposlenik = new AktivnostZaposlenik
                {
                    AktivnostID = AktivnostID,
                    ZaposlenikID = i
                };

                _zaposlenikAktivnostInterface.Add(zaposlenik);
            }

            return RedirectToAction("DetaljiAktivnosti", new { AktivnostID });
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Izmijeni(int AktivnostID)
        {
            var aktivnost = _aktivnostInterface.Find(AktivnostID);

            return PartialView(aktivnost);
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        [HttpPost]
        public IActionResult Izmijeni(Aktivnost model)
        {
            _aktivnostInterface.Update(model);

            return RedirectToAction("DetaljiAktivnosti", new { AktivnostID = model.ID });
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult ObrisiZaposlenika(int AktivnostID,int ZaposlenikID)
        {
            _zaposlenikAktivnostInterface.Delete(AktivnostID, ZaposlenikID);
            return RedirectToAction(nameof(DetaljiAktivnosti), new { AktivnostID });
        }
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult ObrisiDjecu(int AktivnostID, int DijeteID)
        {
            _dijeteAktivnostInterface.Delete(AktivnostID, DijeteID);
            return RedirectToAction(nameof(DetaljiAktivnosti), new { AktivnostID });
        }
        private List<SelectListItem> CreateSelectListItem(List<Zaposlenik> MyList)
        {
            return MyList.OrderBy(x => x.Ime).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();
        }
        private List<SelectListItem> CreateSelectListItem(List<AktivnostZaposlenik> MyList)
        {
            return MyList.OrderBy(x => x.Zaposlenik.Ime +" "+x.Zaposlenik.Prezime).Select(x => new SelectListItem
            {
                Value = x.ZaposlenikID.ToString(),
                Text = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime
            }).ToList();
        }
        private List<SelectListItem> CreateSelectListItem(List<DijeteAktivnost> MyList)
        {
            return MyList.OrderBy(x => x.Dijete.Ime + " " + x.Dijete.Prezime).Select(x => new SelectListItem
            {
                Value = x.DijeteID.ToString(),
                Text = x.Dijete.Ime + " " + x.Dijete.Prezime
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
    }
}
