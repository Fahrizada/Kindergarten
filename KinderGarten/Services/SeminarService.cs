using KinderGarten.Data;
using KinderGarten.Helper;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    public class SeminarService:ISeminarInterface
    {
        private readonly KinderGartenContext _db;
        public SeminarService(KinderGartenContext db)
        {
            _db = db;
        }
        public List<Seminar> GetAll()
        {
            var lista = _db.Seminar.Include(o => o.Grad).ToList();
            return lista;
        }
        public void AddSeminar(DodajSeminarVM model)
        {
            Seminar seminar = new Seminar();

            seminar.NazivSeminara = model.NazivSeminara;
            seminar.VrijemeSeminaraDo = model.VrijemeSeminaraDo;
            seminar.VrijemeSeminaraOd = model.VrijemeSeminaraOd;
            seminar.Certifikat = model.Certifikat;
            seminar.Adresa = model.Adresa;
            seminar.GradID = model.GradID;


            _db.Seminar.Add(seminar);
            _db.SaveChanges();
           
        }
        public void ObrisiSeminar(int semiarID)
        {
            Seminar s = _db.Seminar.Find(semiarID);
            _db.Seminar.Remove(s);
            _db.SaveChanges();
        }
        public Seminar Find(int SeminarID)
        {
            return _db.Seminar.Include(x => x.Grad).Where(x => x.ID == SeminarID).FirstOrDefault();
        }
        public void Update(DodajSeminarVM model)
        {
            var seminar = _db.Seminar.Find(model.SeminarID);
            seminar.NazivSeminara = model.NazivSeminara;
            seminar.VrijemeSeminaraDo = model.VrijemeSeminaraDo;
            seminar.VrijemeSeminaraOd = model.VrijemeSeminaraOd;
            seminar.Certifikat = model.Certifikat;
            seminar.Adresa = model.Adresa;
            seminar.GradID = model.GradID;

            

            _db.Seminar.Update(seminar);
            _db.SaveChanges();
        }
    }
}
