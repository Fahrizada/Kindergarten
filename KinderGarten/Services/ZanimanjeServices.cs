using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class ZanimanjeServices : IZanimanjeInterface
    {
        private readonly KinderGartenContext _db;
        public ZanimanjeServices(KinderGartenContext db)
        {
            _db = db;
        }
        public List<Zanimanje> GetAll()
        {
            List<Zanimanje> lista = _db.Zanimanje.Select(x => x).ToList();
            return lista;
        }
    }
}
