using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using KinderGarten.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class RadniListServices : IRadniListInterface
    {
        private readonly KinderGartenContext db;
        public RadniListServices(KinderGartenContext db)
        {
            this.db = db;
        }
        public List<RadniList> GetAll()
        {
            var lista = db.RadniList.Include(a => a.Grupa).Include(b => b.ZaposlenikPrvaSmjena)
                .Include(b => b.ZaposlenikDrugaSmjena)
                .ToList();
            return lista;
        }
        public void AddRadniList(DodajRadniListVM model)
        {
            RadniList novi = new RadniList
            {
                Datum = DateTime.UtcNow,
                GrupaID = model.GrupaID,
                Zaposlenik1ID = model.ZaposlenikPrvaSmjenaID,
                Zaposlenik2ID = model.ZaposlenikDrugaSmjenaID
            };
            db.Add(novi);
            db.SaveChanges();
        }

    }
}
