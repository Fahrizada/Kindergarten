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
    public class DjecaService : IDjecaInterface
    {
        private readonly KinderGartenContext _db;
        public DjecaService(KinderGartenContext db)
        {
            _db = db;
        }

        public int AddDijete(DodajDijeteVM model, IFormFile slika)
        {

            Dijete dijete = new Dijete();

            string putanja;
            if (slika != null)
            {
                putanja = ImageUpload.Upload(slika).Result;
                dijete.PutanjaSlike = putanja;
            }


            dijete.Ime = model.Ime;
            dijete.Prezime = model.Prezime;
            dijete.JMBG = model.JMBG;
            dijete.DatumRodjenja = model.DatumRodjenja;
            
            dijete.Napomena = model.Napomena;
            dijete.PosebnePotrebe = model.PosebnePotrebe;
            dijete.GrupaID = model.GrupaID;
            dijete.RoditeljID = model.RoditeljID;
            _db.Dijete.Add(dijete);
            _db.SaveChanges();
            return dijete.ID;
        }

        public List<Dijete> GetAll()
        {
            var lista = _db.Dijete.Include(a => a.Grupa).ToList();
            return lista;
        }

        public bool IzmijeniSliku(int id, string putanja)
        {
            try
            {
                var dijete = _db.Dijete.Find(id);
                dijete.PutanjaSlike = putanja;
                _db.Update(dijete);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ObrisiDijete(int dijeteID)
        {
            Dijete dijete = _db.Dijete.Find(dijeteID);
            _db.Dijete.Remove(dijete);
            _db.SaveChanges();
        }

        public void SacuvajDijete(DodajDijeteVM model)
        {
            Dijete dijete = _db.Dijete.Find(model.ID);

            dijete.Ime = model.Ime;
            dijete.Prezime = model.Prezime;
            dijete.JMBG = model.JMBG;
            dijete.DatumRodjenja = model.DatumRodjenja;
           
            dijete.Napomena = model.Napomena;
            dijete.PosebnePotrebe = model.PosebnePotrebe;
            dijete.GrupaID = model.GrupaID;

            _db.SaveChanges();
        }
    }
}
