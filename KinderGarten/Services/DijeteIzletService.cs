using KinderGarten.Data;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    public class DijeteIzletService : IDijeteIzletInterface
    {
        private readonly KinderGartenContext _db;

        public DijeteIzletService(KinderGartenContext db)
        {
            _db = db;
        }

        public void Add(DijeteIzlet dijete)
        {
            _db.DijeteIzlet.Add(dijete);
            _db.SaveChanges();
        }

        public void Delete(int izletID, int dijeteID)
        {
            var dijeteIzlet = _db.DijeteIzlet.Where(x => x.DijeteID == dijeteID && x.IzletID == izletID).FirstOrDefault();
            _db.DijeteIzlet.Remove(dijeteIzlet);
            _db.SaveChanges();
        }

        public List<Dijete> GetByIzlet(int IzletID)
        {
            return _db.DijeteIzlet.Include(x => x.Dijete).Include(x => x.Izlet).Where(x => x.IzletID == IzletID).Select(x => x.Dijete).ToList();
        }
    }
}
