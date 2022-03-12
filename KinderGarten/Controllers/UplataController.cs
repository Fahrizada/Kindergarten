using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KinderGarten.Controllers
{
    public class UplataController : Controller
    {
        private readonly IUplataInterface _uplataInterface;
        private readonly IDjecaInterface _djecaInterface;
        private readonly IRoditeljInterface _roditeljInterface;
        private readonly IUserInterface _userInterface;
        private readonly IVrstaInterface _vrstaInterface;
        private readonly UserManager<User> _userManager;

        public UplataController(IUplataInterface uplataInterface, IDjecaInterface djecaInterface,
            IRoditeljInterface roditeljInterface, UserManager<User> userManager,
            IUserInterface userInterface, IVrstaInterface vrstaInterface)
        {
            _uplataInterface = uplataInterface;
            _djecaInterface = djecaInterface;
            _roditeljInterface = roditeljInterface;
            _userManager = userManager;
            _userInterface = userInterface;
            _vrstaInterface = vrstaInterface;

        }
        [Authorize(Policy = "AdminOrRoditelj")]
        public IActionResult Index()
        {
            User u=_userInterface.FindByID(_userManager.GetUserId(User));
            if (u.Role == "Roditelj")
            {
                string e = u.Email;
                return View(_uplataInterface.GetAllbyEmail(e));
            }
            else 
            return View(_uplataInterface.GetAll());
        }
        [Authorize(Policy = "Admin")]
        public IActionResult DodajUplatu()
        {
            List<SelectListItem> roditelji = CreateSelectListItem(_roditeljInterface.GetAll());
            List<SelectListItem> djeca = CreateSelectListItem(_djecaInterface.GetAll());
            List<SelectListItem> vrsta = CreateSelectListItem(_vrstaInterface.GetAll());
            var model = new DodajUplatuVM
            {
                Roditelj = roditelji,
                Dijete=djeca,
                VrstaUplate=vrsta
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult DodajUplatu(DodajUplatuVM model)
        {
            _uplataInterface.AddUplatu(model);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Admin")]
        public IActionResult ObrisiUplatu(int UplataID)
        {
            _uplataInterface.ObrisiUplatu(UplataID);
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "AdminOrRoditelj")]
        public IActionResult DetaljiUplate(int UplataID)
        {
            var uplata = _uplataInterface.FindByID(UplataID);
            return View(uplata);
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Izmijeni(int UplataID)
        {
            List<SelectListItem> roditelji = CreateSelectListItem(_roditeljInterface.GetAll());
            List<SelectListItem> djeca = CreateSelectListItem(_djecaInterface.GetAll());
            List<SelectListItem> vrsta = CreateSelectListItem(_vrstaInterface.GetAll());
            var uplata = new IzmijeniUplatuVM
            {
                Uplata = _uplataInterface.FindByID(UplataID),
                Dijete=djeca,
                Roditelj=roditelji,
                VrstaUplate=vrsta
            };
            return View(uplata);
        }
        
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Izmijeni(IzmijeniUplatuVM model)
        {
            var uplata = new Uplata
            {
                DatumUplate=model.Uplata.DatumUplate,
                Iznos=model.Uplata.Iznos,
                DijeteID=model.Uplata.DijeteID,
                RoditeljID=model.Uplata.RoditeljID,
                VrstaUplateID=model.Uplata.VrstaUplateID,
                ID=model.Uplata.ID
            };
            _uplataInterface.Update(uplata);
            return RedirectToAction(nameof(DetaljiUplate),new { UplataID = uplata.ID });
        }
        private List<SelectListItem> CreateSelectListItem(List<Dijete> MyList)
        {
            return MyList.OrderBy(x => x.Ime).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();
        }
        private List<SelectListItem> CreateSelectListItem(List<Roditelj> MyList)
        {
            return MyList.OrderBy(x => x.Ime).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Ime + " " + x.Prezime
            }).ToList();
        }
        private List<SelectListItem> CreateSelectListItem(List<VrstaUplate> MyList)
        {
            return MyList.OrderBy(x => x.Vrsta).Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Vrsta
            }).ToList();
        }
    }
}
