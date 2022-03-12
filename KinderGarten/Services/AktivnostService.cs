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
    public class AktivnostService : IAktivnostInterface
    {
        private readonly KinderGartenContext _db;
        public AktivnostService(KinderGartenContext db)
        {
            _db = db;
        }
        public List<Aktivnost> GetAll()
        {
            return _db.Aktivnost.ToList();
        }
        public void Add(Aktivnost model)
        {
           
            _db.Aktivnost.Add(model);
            _db.SaveChanges();

        }
        public void Delete(int AktivnostID)
        {
            Aktivnost aktivnost = _db.Aktivnost.Find(AktivnostID);
            _db.Aktivnost.Remove(aktivnost);
            _db.SaveChanges();

        }
        public Aktivnost Find(int AktivnostID)
        {
            return _db.Aktivnost.Find(AktivnostID);
        }
        public void Update(Aktivnost model)
        {
            
            _db.Aktivnost.Update(model);
            _db.SaveChanges();
        }

    }
}
