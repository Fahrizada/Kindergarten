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
    public class IzletZaposleniciServis : IIzletZaposleniciInterface
    {
        private readonly KinderGartenContext _db;
        public IzletZaposleniciServis(KinderGartenContext db)
        {
            _db = db;
        }

        public void Add(IzletZaposlenici zaposlenik)
        {
            _db.IzletZaposlenici.Add(zaposlenik);
            _db.SaveChanges();
        }

        public void Delete(int izletID, int zaposlenikID)
        {
            var iz = _db.IzletZaposlenici.Where(o => o.IzletID == izletID && o.ZaposlenikID == zaposlenikID)
                .FirstOrDefault();
            _db.IzletZaposlenici.Remove(iz);
            _db.SaveChanges();
        }

        public List<IzletZaposlenici> GetByIzlet(int IzletID)
        {
            return _db.IzletZaposlenici.Include(x => x.Zaposlenik).Where(x => x.IzletID == IzletID).ToList();
        }
    }
}
