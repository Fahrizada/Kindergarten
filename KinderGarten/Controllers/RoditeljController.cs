using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinderGarten.Helper;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KinderGarten.Controllers
{
   
    public class RoditeljController : Controller
    {
        private readonly IRoditeljInterface _roditeljInterface;
        private readonly UserManager<User> _userManager;
        private readonly IUserInterface _userInterface;
        public RoditeljController(IRoditeljInterface roditeljInterface,
                                    UserManager<User> userManager,
                                    IUserInterface userInterface)
        {
            _roditeljInterface = roditeljInterface;
            _userManager = userManager;
            _userInterface = userInterface;
        }
        [Authorize(Policy = "Admin")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 2;
            var OnePageOfRoditelj = _roditeljInterface.GetAll().ToPagedList(pageNumber, pageSize);
            return View("PrikazRoditelja", OnePageOfRoditelj);
            
        }
        [Authorize(Policy = "Admin")]
        public IActionResult DodajRoditelja(){
            Roditelj roditelj = new Roditelj();

            return PartialView("DodajRoditelja",roditelj);
        }
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult DodajRoditelja(Roditelj model, IFormFile slika = null)
        {
            
            var user = new User
            {
                Email = model.Email,
                Role = "Roditelj",
                Adresa = model.Adresa,
                BrojTelefona = model.BrojTelefona,
                EmailConfirmed = true,
                Ime = model.Ime,
                Prezime = model.Prezime,
                UserName = model.Email,
                NormalizedEmail = model.Email,
                NormalizedUserName = model.Email
            };
            _userManager.CreateAsync(user, "Test-123");
            var claim = new IdentityUserClaim<string>
            {
                ClaimType = "Role",
                ClaimValue = "Roditelj"
            };
            _userInterface.SaveUser(user, claim);
            _roditeljInterface.AddRoditelj(model, slika);

            return RedirectToAction("Index");
        }
        [Authorize(Policy = "Admin")]
        public IActionResult ObrisiRoditelja(int RoditeljID)
        {
            Roditelj roditelj = _roditeljInterface.FindRoditeljByID(RoditeljID);
            User user = _userInterface.FindByEmail(roditelj.Email);
            _userInterface.DeleteUser(user.Id);
            _roditeljInterface.ObrisiRoditelja(roditelj.ID);

            return RedirectToAction("Index");
        }
        [Authorize(Policy = "AdminOrRoditelj")]
        public IActionResult DetaljiRoditelja(int RoditeljID) 
        {
            Roditelj roditelj = _roditeljInterface.FindRoditeljByID(RoditeljID);
            return View(roditelj); 
        }
        [Authorize(Policy = "AdminOrRoditelj")]
        public IActionResult Izmijeni(int RoditeljID)
        {
            Roditelj roditelj = _roditeljInterface.FindRoditeljByID(RoditeljID);
            return View("IzmijeniRoditelja",roditelj);

        }
        
        [HttpPost]
        [Authorize(Policy = "AdminOrRoditelj")]
        public IActionResult IzmijeniRoditelja(Roditelj roditelj)
        {

            _roditeljInterface.Update(roditelj);
            return RedirectToAction(nameof(DetaljiRoditelja),new { RoditeljID =roditelj.ID});
        }

        [HttpPost]
        public async Task<IActionResult> SpremiSliku([FromForm] IFormFile file, [FromQuery] int Roditelj)
        {
            string path = await ImageUpload.Upload(file);
            _roditeljInterface.IzmijeniSliku(Roditelj, path);
            return RedirectToAction(nameof(Index));
        }
    }
}
