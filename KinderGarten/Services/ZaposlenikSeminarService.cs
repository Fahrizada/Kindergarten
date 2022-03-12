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
    public class ZaposlenikSeminarService : IZaposlenikSeminarInterface
    {
        private readonly KinderGartenContext _db;
        public ZaposlenikSeminarService(KinderGartenContext db)
        {
            _db = db;
        }

        public void Add(ZaposlenikSeminar zaposlenik)
        {
            _db.ZaposlenikSeminar.Add(zaposlenik);
            _db.SaveChanges();
        }

        public void Delete(int seminarID, int zaposlenikID)
        {
            var sz = _db.ZaposlenikSeminar.Where(o => o.SeminarID == seminarID && o.ZaposlenikID == zaposlenikID)
                .FirstOrDefault();
            _db.ZaposlenikSeminar.Remove(sz);
            _db.SaveChanges();
        }

        public List<ZaposlenikSeminar> GetBySeminar(int SeminarID)
        {
            return _db.ZaposlenikSeminar.Include(x => x.Zaposlenik).Where(x => x.SeminarID == SeminarID).ToList();
        }
    }

}
