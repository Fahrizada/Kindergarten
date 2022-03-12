using KinderGarten.Data;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    public class IzletService : IIzletInterface
    {
        private readonly KinderGartenContext _db;
        public IzletService(KinderGartenContext db)
        {
            _db = db;
        }
        public List<Izlet> GetAll()
        {
            return _db.Izlet.ToList();
        }

        public void Add(DodajIzletVM model)
        {
            Izlet izlet = new Izlet
            {
                Lokacija = model.Lokacija,
                DatumIzletaOd = model.DatumIzletaOd,
                DatumIzletaDo = model.DatumIzletaDo
            };

            _db.Izlet.Add(izlet);
            _db.SaveChanges();
        }

        public void Delete(int IzletID)
        {
            var Izlet = _db.Izlet.Find(IzletID);

            _db.Izlet.Remove(Izlet);
            _db.SaveChanges();
        }

        public Izlet Find(int IzletID)
        {
            return _db.Izlet.Find(IzletID);
        }

        public void Update(DodajIzletVM model)
        {
            var izlet = _db.Izlet.Find(model.IzletID);

            izlet.DatumIzletaOd = model.DatumIzletaOd;
            izlet.DatumIzletaDo = model.DatumIzletaDo;
            izlet.Lokacija = model.Lokacija;

            _db.Izlet.Update(izlet);
            _db.SaveChanges();
        }
    }
}
