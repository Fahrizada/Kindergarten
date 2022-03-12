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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KinderGarten.Controllers
{
    public class ZaposlenikController : Controller
    {
        private readonly IZaposlenikInterface _zaposlenikInterface;
        private readonly IZanimanjeInterface _zanimanjeInterface;
        private readonly IStrucnaSpremaInterface _strucnaSpremaInterface;
        private readonly IUserInterface _userInterface;
        private readonly UserManager<User> _userManager;

        public ZaposlenikController(IZaposlenikInterface zaposlenikInterface,
                                    IZanimanjeInterface zanimanjeInterface,
                                    IStrucnaSpremaInterface strucnaSpremaInterface,
                                    IUserInterface userInterface,
                                    UserManager<User> userManager)
        {
            _zaposlenikInterface = zaposlenikInterface;
            _zanimanjeInterface = zanimanjeInterface;
            _strucnaSpremaInterface = strucnaSpremaInterface;
            _userInterface = userInterface;
            _userManager = userManager;
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            var lista = _zaposlenikInterface.GetAll();
            return View("PrikazZaposlenika",lista);
        }

        [Authorize(Policy = "Admin")]
        public IActionResult DodajZaposlenika()
        {
            List<SelectListItem> strSprema = CreateSelectListItem(_strucnaSpremaInterface.GetAll());
            List<SelectListItem> zanimanje = CreateSelectListItem(_zanimanjeInterface.GetAll());

            DodajZaposlenikaVM zaposlenik = new DodajZaposlenikaVM();
            zaposlenik.StrucnaSprema = strSprema;
            zaposlenik.Zanimanje = zanimanje;
            return PartialView("DodajZaposlenika", zaposlenik);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult DodajZaposlenika(DodajZaposlenikaVM modal, IFormFile slika = null)
        {
            var user = new User
            {
                Email = modal.Email,
                Role = "Zaposlenik",
                Adresa = modal.Adresa,
                BrojTelefona = modal.BrojTelefona,
                EmailConfirmed = true,
                Ime = modal.Ime,
                Prezime = modal.Prezime,
                UserName = modal.Email,
                NormalizedEmail = modal.Email,
                NormalizedUserName = modal.Email
            };
            _userManager.CreateAsync(user, "Test-123");
            var claim = new IdentityUserClaim<string>
            {
                ClaimType = "Role",
                ClaimValue = "Zaposlenik"
            };
            _userInterface.SaveUser(user, claim);
            _zaposlenikInterface.AddZaposlenik(modal,slika);
           

            return RedirectToAction("Index");
        }

        private List<SelectListItem> CreateSelectListItem(List<Zanimanje> list)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in list)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Naziv });
            return sol;
        }

        private List<SelectListItem> CreateSelectListItem(List<StrucnaSprema> list)
        {
            List<SelectListItem> sol = new List<SelectListItem>();
            foreach (var item in list)
                sol.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Naziv });
            return sol;
        }

        [Authorize(Policy = "Admin")]
        public IActionResult ObrisiZaposlenika(int ZaposlenikID)
        {
            Zaposlenik zaposlenik = _zaposlenikInterface.FindZaposlenikByID(ZaposlenikID);
            User user=_userInterface.FindByEmail(zaposlenik.Email);
            _userInterface.DeleteUser(user.Id);
            _zaposlenikInterface.ObrisiZaposlenika(zaposlenik.ID);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Izmijeni(int ZaposlenikID)
        {
            var model = _zaposlenikInterface.GetAll().Where(x => x.ID == ZaposlenikID).SingleOrDefault();

            List<SelectListItem> strSprema = CreateSelectListItem(_strucnaSpremaInterface.GetAll());
            List<SelectListItem> zanimanje = CreateSelectListItem(_zanimanjeInterface.GetAll());


            DodajZaposlenikaVM editZaposlenik = new DodajZaposlenikaVM()
            {
                StrucnaSpremaID = model.StrucnaSpremaID,
                ZanimanjeID=model.ZanimanjeID,
                ID = model.ID,
                JMBG = model.JMBG,
                Ime=model.Ime,
                Prezime=model.Prezime,
                DatumRodjenja=model.DatumRodjenja,
                Adresa=model.Adresa,
                BrojTelefona=model.BrojTelefona,
                Email=model.Email,
                StrucnaSprema=strSprema,
                Zanimanje = zanimanje
            };

            return PartialView("IzmijeniZaposlenika", editZaposlenik);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Izmijeni(DodajZaposlenikaVM model)
        {
            _zaposlenikInterface.SacuvajZaposlenika(model);
            return RedirectToAction(nameof(Detalji),new { ZaposlenikID=model.ID });
        }

        [Authorize(Policy = "AdminOrZaposlenik")]
        public IActionResult Detalji(int ZaposlenikID)
        {
            var zaposlenik = _zaposlenikInterface.GetAll().Where(x => x.ID == ZaposlenikID).FirstOrDefault();
            return View("DetaljiZaposlenika", zaposlenik);
        }
        [HttpPost]
        public async Task<IActionResult> SpremiSliku([FromForm]IFormFile file, [FromQuery]int Zaposlenik)
        {
            string path = await ImageUpload.Upload(file);
            _zaposlenikInterface.IzmijeniSliku(Zaposlenik, path);
            return RedirectToAction(nameof(Index));
        }
    }
}