using System.Collections.Generic;
using System.Linq;
using KinderGarten.Data;
using KinderGarten.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KinderGarten.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KinderGartenContext _context;
        private readonly IAuthorizationService _AuthorizationService;
        private readonly UserManager<User> _UserManager;

        public HomeController(ILogger<HomeController> logger,
            KinderGartenContext context, UserManager<User> UserManager,
            IAuthorizationService AuthorizationService
            )
        {
            _logger = logger;
            _context = context;
            _AuthorizationService = AuthorizationService;
            _UserManager = UserManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _context.User.Find(_UserManager.GetUserId(User));
            return View(user);
        }

        public IActionResult Demo()
        {
            // find in db
            // store
            // delete ...

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Initialize()
        {
            if (!_context.StrucnaSprema.Any())
            {
                List<StrucnaSprema> strucneSpreme = new List<StrucnaSprema>
                {
                    new StrucnaSprema { Naziv = "IV Stepen - Srednja škola" },
                    new StrucnaSprema { Naziv = "V Stepen - VKV - SSS srednja škola" },
                    new StrucnaSprema { Naziv = "VI Stepen - VŠS viša škola" },
                    new StrucnaSprema { Naziv = "VII Stepen - VSS visoka strucna sprema" },
                    new StrucnaSprema { Naziv = "VII-1 Stepen - Specijalista" },
                    new StrucnaSprema { Naziv = "VII-2 Stepen - Magistratura" }
                };
                _context.AddRange(strucneSpreme);
            }

            if (!_context.Zanimanje.Any())
            {
                List<Zanimanje> zanimanja = new List<Zanimanje>
                {
                    new Zanimanje { Naziv = "Odgajatelj" },
                    new Zanimanje { Naziv = "Asistent" },
                    new Zanimanje { Naziv = "Direktor" },
                    new Zanimanje { Naziv = "Sekretar" },
                    new Zanimanje { Naziv = "Kuhar" },
                    new Zanimanje { Naziv = "Domar" },
                    new Zanimanje { Naziv = "Pomocno osoblje" }
                };
                _context.AddRange(zanimanja);
            }

            if (!_context.Grupa.Any())
            {
                List<Grupa> grupe = new List<Grupa>
                {
                    new Grupa { Naziv = "Jaslice" },
                    new Grupa { Naziv = "Srednja" },
                    new Grupa { Naziv = "Predškolska" },
                    new Grupa { Naziv = "Produzeni boravak" }
                };
                _context.AddRange(grupe);
            }

            if (!_context.OvlastenaOsoba.Any())
            {
                List<OvlastenaOsoba> ovlasteneOsobe = new List<OvlastenaOsoba>
                {
                    new OvlastenaOsoba { Ime = "Adil", Prezime = "Joldic", Zaposlen = true, StrucnaSpremaID = 1 },
                    new OvlastenaOsoba { Ime = "Denis", Prezime = "Music", Zaposlen = false, StrucnaSpremaID = 4 }
                };
                _context.AddRange(ovlasteneOsobe);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
