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
    public class ZaposlenikAktivnostService: IZaposlenikAktivnostInterface
    {
        private readonly KinderGartenContext _db;
        public ZaposlenikAktivnostService(KinderGartenContext db)
        {
            _db = db;
        }
        public void Add(AktivnostZaposlenik zaposlenik)
        {
            _db.AktivnostZaposlenik.Add(zaposlenik);
            _db.SaveChanges();
        }

        public void Delete(int aktivnostID, int zaposlenikID)
        {
            var az = _db.AktivnostZaposlenik.Where(o => o.AktivnostID == aktivnostID && o.ZaposlenikID == zaposlenikID)
                .FirstOrDefault();
            _db.AktivnostZaposlenik.Remove(az);
            _db.SaveChanges();
        }

        public List<AktivnostZaposlenik> GetByAktivnost(int AktivnostID)
        {
            return _db.AktivnostZaposlenik.Include(x => x.Zaposlenik).
              Include(x => x.Aktivnost).Where(x => x.AktivnostID == AktivnostID).ToList();

        }
    }
}
