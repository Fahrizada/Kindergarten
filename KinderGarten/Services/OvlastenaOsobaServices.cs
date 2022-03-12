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
    public class OvlastenaOsobaServices : IOvlastenaOsobaInterface
    {
        private readonly KinderGartenContext _db;
        public OvlastenaOsobaServices(KinderGartenContext db)
        {
            _db = db;
        }
        public List<OvlastenaOsoba> GetAll()
        {
            var lista = _db.OvlastenaOsoba.Include(a => a.StrucnaSprema).ToList();
            return lista;
        }
        public void AddOvlastenaOsoba(DodajOvlastenuOsobuVM model,IFormFile slika)
        {
            OvlastenaOsoba ovlastenaOsoba = new OvlastenaOsoba();

            string putanja;
            if (slika != null)
            {
                putanja = ImageUpload.Upload(slika).Result;
                ovlastenaOsoba.PutanjaSlike = putanja;
            }
            ovlastenaOsoba.Ime = model.Ime;
            ovlastenaOsoba.Prezime = model.Prezime;
            ovlastenaOsoba.JMBG = model.JMBG;
            ovlastenaOsoba.DatumRodjenja = model.DatumRodjenja;
            ovlastenaOsoba.Adresa = model.Adresa;
            ovlastenaOsoba.BrojTelefona = model.BrojTelefona;
            ovlastenaOsoba.Email = model.Email;
            ovlastenaOsoba.StrucnaSpremaID = model.StrucnaSpremaID;
            ovlastenaOsoba.Aktivan = model.Aktivan;
            ovlastenaOsoba.Zaposlen = model.Zaposlen;
            _db.OvlastenaOsoba.Add(ovlastenaOsoba);
            _db.SaveChanges();


            DijeteOvlastenaOsoba dijeteOvlastenaOsoba = new DijeteOvlastenaOsoba();
            dijeteOvlastenaOsoba.DijeteID = model.DijeteID;
            dijeteOvlastenaOsoba.OvlastenaOsobaID = ovlastenaOsoba.ID;
            _db.DijeteOvlastenaOsoba.Add(dijeteOvlastenaOsoba);
            _db.SaveChanges();


        }

        public void ObrisiOvlastenaOsoba(int OvlastenaOsobaID)
        {
            OvlastenaOsoba ovlastenaOsoba = _db.OvlastenaOsoba.Find(OvlastenaOsobaID);
            _db.OvlastenaOsoba.Remove(ovlastenaOsoba);
            _db.SaveChanges();
        }

        public void SacuvajOvlastenaOsoba(DodajOvlastenuOsobuVM model)
        {
            OvlastenaOsoba ovlastenaOsoba = _db.OvlastenaOsoba.Find(model.ID);
            ovlastenaOsoba.Ime = model.Ime;
            ovlastenaOsoba.Prezime = model.Prezime;
            ovlastenaOsoba.JMBG = model.JMBG;
            ovlastenaOsoba.DatumRodjenja = model.DatumRodjenja;
            ovlastenaOsoba.Adresa = model.Adresa;
            ovlastenaOsoba.BrojTelefona = model.BrojTelefona;
            ovlastenaOsoba.Email = model.Email;
            ovlastenaOsoba.StrucnaSpremaID = model.StrucnaSpremaID;
            
            _db.SaveChanges();
        }

        public List<OvlastenaOsoba> GetByDijeteID(int DijeteID)
        {
            var lista = _db.DijeteOvlastenaOsoba.Where(x => x.DijeteID == DijeteID).Select(a => a.OvlastenaOsoba).ToList();
            return lista;
        }

        public bool IzmijeniSliku(int id, string putanja)
        {
            try
            {
                var ovlastenaOsoba = _db.OvlastenaOsoba.Find(id);
                ovlastenaOsoba.PutanjaSlike = putanja;
                _db.Update(ovlastenaOsoba);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
