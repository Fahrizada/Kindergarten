using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class DrzavaService : IDrzavaInterface
    {
        private readonly KinderGartenContext _db;
        
        public DrzavaService(KinderGartenContext db)
        {
            _db = db;
        }

        public void AddDrzava(Drzava drzava)
        {
            Drzava nova = new Drzava();
            nova.Naziv = drzava.Naziv;
            _db.Drzava.Add(nova);
            _db.SaveChanges();
        }

        public List<Drzava> GetAll()
        {
            var listaDrzava = _db.Drzava.Select(x => x).ToList();

            return listaDrzava;
        }

        public void RemoveDrzava(int drzavaID)
        {
            var drzava = _db.Drzava.Find(drzavaID);
            _db.Drzava.Remove(drzava);
            _db.SaveChanges();
        }

        public void SacuvajDrzavu(Drzava drzava)
        {
            var editDrzava = _db.Drzava.Find(drzava.ID);
            editDrzava.Naziv = drzava.Naziv;
            _db.SaveChanges();
        }

        public Drzava GetByName(string name)
        {
            return _db.Drzava.Where(x => x.Naziv == name).FirstOrDefault();
        }
    }
}
