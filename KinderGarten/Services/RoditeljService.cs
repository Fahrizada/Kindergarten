using KinderGarten.Data;
using KinderGarten.Helper;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    public class RoditeljService: IRoditeljInterface
    {
        private readonly KinderGartenContext _db;
        public RoditeljService(KinderGartenContext db)
        {
            _db = db;
        }
        public List<Roditelj> GetAll()
        {
            var lista = _db.Roditelj.ToList();
            return lista;
        }
        public void AddRoditelj(Roditelj model, IFormFile slika)
        {
            Roditelj roditelj = new Roditelj();
            string putanja;
            if (slika != null)
            {
                putanja = ImageUpload.Upload(slika).Result;
                roditelj.PutanjaSlike = putanja;
            }
            roditelj.Ime = model.Ime;
            roditelj.Prezime = model.Prezime;
            roditelj.JMBG = model.JMBG;
            roditelj.Adresa = model.Adresa;
            roditelj.DatumRodjenja = model.DatumRodjenja;
            roditelj.BrojTelefona = model.BrojTelefona;
            roditelj.Email = model.Email;
            _db.Roditelj.Add(roditelj);
            _db.SaveChanges();
        }
        public void ObrisiRoditelja(int RoditeljID)
        {
            Roditelj roditelj = _db.Roditelj.Find(RoditeljID);
            _db.Roditelj.Remove(roditelj);
            _db.SaveChanges();
            
        }
        public Roditelj FindRoditeljByID(int RoditeljID)
        {
            Roditelj roditelj = _db.Roditelj.Find(RoditeljID);
            return roditelj;
        }
        public void Update(Roditelj model)
        {
            Roditelj roditelj = _db.Roditelj.Find(model.ID);
            roditelj.Ime = model.Ime;
            roditelj.Prezime = model.Prezime;
            roditelj.JMBG = model.JMBG;
            roditelj.Adresa = model.Adresa;
            roditelj.Email = model.Email;
            roditelj.BrojTelefona = model.BrojTelefona;

            _db.Roditelj.Update(roditelj);
            _db.SaveChanges();
        }
        public bool IzmijeniSliku(int id, string putanja)
        {
            try
            {
                var roditelj = _db.Roditelj.Find(id);
                roditelj.PutanjaSlike = putanja;
                _db.Roditelj.Update(roditelj);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Roditelj FindRoditeljByEmail(string Email)
        {
            return _db.Roditelj.Where(x => x.Email == Email).FirstOrDefault();
        }
    }
}
