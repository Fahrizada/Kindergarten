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
    public class DijeteAktivnostService: IDijeteAktivnostInterface
    {
        private readonly KinderGartenContext _db;
        public DijeteAktivnostService(KinderGartenContext db)
        {
            _db = db;
        }
        public void Add(DijeteAktivnost dijete)
        {
            _db.DijeteAktivnost.Add(dijete);
            _db.SaveChanges();

        }

        public void Delete(int aktivnostID, int dijeteID)
        {
            var ad = _db.DijeteAktivnost.Where(o => o.AktivnostID == aktivnostID && o.DijeteID == dijeteID)
                .FirstOrDefault();
            _db.DijeteAktivnost.Remove(ad);
            _db.SaveChanges();
        }

        public List<DijeteAktivnost> GetByAktivnost(int AktivnostID)
        {
            return _db.DijeteAktivnost.Include(x => x.Dijete).
                Include(x => x.Aktivnost).Where(x => x.AktivnostID == AktivnostID).ToList();

        }
    }
}
