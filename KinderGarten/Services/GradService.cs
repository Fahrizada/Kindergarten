using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using KinderGarten.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class GradService : IGradInterface
    {
        private readonly KinderGartenContext _db;
        public GradService(KinderGartenContext db)
        {
            _db = db;
        }

        public void AddGrad(DodajGradVM grad)
        {
            Grad noviGrad = new Grad();

            noviGrad.Naziv = grad.Naziv;
            noviGrad.PostanskiBroj = grad.PostasnkiBroj;
            noviGrad.DrzavaID = grad.DrzavaID;

            _db.Grad.Add(noviGrad);
            _db.SaveChanges();
        }

        public void DeleteGrad(int id)
        {
            Grad grad = _db.Grad.Find(id);
            _db.Grad.Remove(grad);
            _db.SaveChanges();
        }

        public List<Grad> GetAll()
        {
            var listaGradova = _db.Grad.Select(x => x).Include(a => a.Drzava).ToList();

            return listaGradova;
        }

        public void SacuvajGrad(DodajGradVM model)
        {
            Grad editGrad = _db.Grad.Find(model.ID);

            editGrad.PostanskiBroj = model.PostasnkiBroj;
            editGrad.Naziv = model.Naziv;
            editGrad.DrzavaID = model.DrzavaID;
            

            _db.SaveChanges();
        }

        public void DodajGrad(Grad grad)
        {
            _db.Grad.Add(grad);
            _db.SaveChanges();
        }
    }
}
