using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class GrupeServices : IGrupaInterface
    {
        private readonly KinderGartenContext _db;
        public GrupeServices(KinderGartenContext db)
        {
            _db = db;
        }
        public List<Grupa> GetAll()
        {
            var lista = _db.Grupa.Select(x => x).ToList();
            return lista;
        }
    }
}
