using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace KinderGarten.Controllers
{
    public class SeminarController : Controller
    {
        private readonly ISeminarInterface _seminarInterface;
        private readonly IGradInterface _gradInteface;
        private readonly IZaposlenikInterface _zaposlenikInteface;
        private readonly IZaposlenikSeminarInterface _zaposlenikSeminarInterface;

        public SeminarController(ISeminarInterface seminar,IGradInterface grad, IZaposlenikInterface zaposlenikInteface,
            IZaposlenikSeminarInterface zaposlenikSeminarInterface)
        {
            _gradInteface = grad;
            _seminarInterface = seminar;
            _zaposlenikInteface = zaposlenikInteface;
            _zaposlenikSeminarInterface = zaposlenikSeminarInterface;
        }
        
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajSeminar()
        {
            List<SelectListItem> grad = CreateSelectListItem(_gradInteface.GetAll());
            DodajSeminarVM s = new DodajSeminarVM();
            s.Gradovi = grad;
            return PartialView("DodajSeminar",s);
        }
        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajSeminar(DodajSeminarVM model)
        {
            _seminarInterface.AddSeminar(model);
            return RedirectToAction("Index");
        }
        private List<SelectListItem> CreateSelectListItem(List<Grad> MyList)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in MyList)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Naziv });
            return sol;
        }
       
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 2;
            var OnePageOfSeminar = _seminarInterface.GetAll().ToPagedList(pageNumber, pageSize);
            return View("PrikazSeminara", OnePageOfSeminar);

        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult ObrisiSeminar(int SeminarID)
        {
            _seminarInterface.ObrisiSeminar(SeminarID);
            return RedirectToAction("Index");
        }
        
        public IActionResult Detalji(int SeminarID)
        {
            var ZaposlenikSeminar = new ZaposlenikSeminarVM
            {
                Seminar = _seminarInterface.Find(SeminarID),
                Zaposlenici =_zaposlenikInteface.GetAll(),
                ZaposlenikSeminar=_zaposlenikSeminarInterface.GetBySeminar(SeminarID)
            };
            return View( ZaposlenikSeminar);
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Izmijeni(int SeminarID)
        {
            var seminar = _seminarInterface.Find(SeminarID);

            var grad = CreateSelectListItem(_gradInteface.GetAll());

            var model = new DodajSeminarVM
            {
                 Adresa=seminar.Adresa,
                 Certifikat=seminar.Certifikat,
                 GradID=seminar.GradID,
                 Gradovi=grad,
                 NazivSeminara=seminar.NazivSeminara,
                 VrijemeSeminaraDo=seminar.VrijemeSeminaraDo,
                 VrijemeSeminaraOd=seminar.VrijemeSeminaraOd,
                 SeminarID=seminar.ID
               
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Izmijeni(DodajSeminarVM model)
        {
            _seminarInterface.Update(model);

            return RedirectToAction(nameof(Detalji), new { SeminarID = model.SeminarID });
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajZaposlenika(int SeminarID)
        {
            var SviZaposlenici = CreateSelectListItem(_zaposlenikInteface.GetAll());
            var ZaposleniciNaIzletu = CreateSelectListItem(_zaposlenikSeminarInterface.GetBySeminar(SeminarID));

            var OdsutniZaposlenici = SviZaposlenici;

            if (ZaposleniciNaIzletu != null)
            {
                OdsutniZaposlenici = SviZaposlenici.Concat(ZaposleniciNaIzletu)
               .GroupBy(x => x.Text)
               .Where(x => x.Count() == 1)
               .Select(x => x.FirstOrDefault())
               .ToList();
            }

            var zaposlenici = new DodajZaposlenikaSeminarVM
            {
                Zaposlenici = OdsutniZaposlenici,
                SeminarID = SeminarID
            };

            return PartialView(zaposlenici);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult DodajZaposlenika(int SeminarID, DodajZaposlenikaSeminarVM model)
        {
            foreach (var i in model.DodavanjaIDs)
            {
                var zaposlenik = new ZaposlenikSeminar
                {
                    SeminarID = SeminarID,
                    ZaposlenikID = i
                };

                _zaposlenikSeminarInterface.Add(zaposlenik);
            }

            return RedirectToAction(nameof(Detalji), new { SeminarID });
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult ObrisiZaposlenika(int SeminarID, int ZaposlenikID)
        {
            _zaposlenikSeminarInterface.Delete(SeminarID, ZaposlenikID);
            return RedirectToAction(nameof(Detalji), new { SeminarID });
        }
      


        private List<SelectListItem> CreateSelectListItem(List<Zaposlenik> MyList)
        {
            return MyList.OrderBy(x => x.Ime).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();
        }
        private List<SelectListItem> CreateSelectListItem(List<ZaposlenikSeminar> MyList)
        {
            return MyList.OrderBy(x => x.Zaposlenik.Ime).Select(x => new SelectListItem
            {
                Value = x.Zaposlenik.ID.ToString(),
                Text = x.Zaposlenik.Ime + " " + x.Zaposlenik.Prezime
            }).ToList();
        }

    }


    
}
