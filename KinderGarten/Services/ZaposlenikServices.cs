using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using KinderGarten.Helper;
using KinderGarten.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class ZaposlenikServices : IZaposlenikInterface
    {
        private readonly KinderGartenContext _db;
        public ZaposlenikServices(KinderGartenContext db)
        {
            _db = db;
        }

        public List<Zaposlenik> GetAll()
        {
            var lista = _db.Zaposlenik.Include(a => a.StrucnaSprema).Include(b => b.Zanimanje).ToList();
            return lista;
        }
        public void AddZaposlenik(DodajZaposlenikaVM model,IFormFile slika)
        {
            Zaposlenik zaposlenik = new Zaposlenik();
            string putanja;
            if (slika != null)
            {
                putanja = ImageUpload.Upload(slika).Result;
                zaposlenik.PutanjaSlike = putanja;
            }
            zaposlenik.Ime = model.Ime;
            zaposlenik.Prezime = model.Prezime;
            zaposlenik.JMBG = model.JMBG;
            zaposlenik.DatumRodjenja = model.DatumRodjenja;
            zaposlenik.Adresa = model.Adresa;
            zaposlenik.BrojTelefona = model.BrojTelefona;
            zaposlenik.Email = model.Email;
            zaposlenik.StrucnaSpremaID = model.StrucnaSpremaID;
            zaposlenik.ZanimanjeID = model.ZanimanjeID;
            _db.Zaposlenik.Add(zaposlenik);
            _db.SaveChanges();
        }

        public void ObrisiZaposlenika(int ZaposlenikID)
        {
            Zaposlenik zaposlenik = _db.Zaposlenik.Find(ZaposlenikID);
            _db.Zaposlenik.Remove(zaposlenik);
            _db.SaveChanges();
        }

        public void SacuvajZaposlenika(DodajZaposlenikaVM model)
        {
            Zaposlenik zaposlenik = _db.Zaposlenik.Find(model.ID);

            zaposlenik.Ime = model.Ime;
            zaposlenik.Prezime = model.Prezime;
            zaposlenik.JMBG = model.JMBG;
            zaposlenik.DatumRodjenja = model.DatumRodjenja;
            zaposlenik.Adresa = model.Adresa;
            zaposlenik.BrojTelefona = model.BrojTelefona;
            zaposlenik.Email = model.Email;
            zaposlenik.StrucnaSpremaID = model.StrucnaSpremaID;
            zaposlenik.ZanimanjeID = model.ZanimanjeID;

            _db.SaveChanges();
        }
        public bool IzmijeniSliku(int id, string putanja)
        {
            try
            {
                var zaposlenik = _db.Zaposlenik.Find(id);
                zaposlenik.PutanjaSlike = putanja;
                _db.Update(zaposlenik);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Zaposlenik FindZaposlenikByID(int ZaposlenikID)
        {
            Zaposlenik zaposlenik = _db.Zaposlenik.Find(ZaposlenikID);
            return zaposlenik;
        }

        public Zaposlenik FindZaposlenikByEmail(string Email)
        {
            return _db.Zaposlenik.Where(x => x.Email == Email).FirstOrDefault();
        }
    }
}
