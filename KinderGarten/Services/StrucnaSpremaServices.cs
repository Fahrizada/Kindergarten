using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class StrucnaSpremaServices: IStrucnaSpremaInterface
    {
        private readonly KinderGartenContext _db;
        public StrucnaSpremaServices(KinderGartenContext db)
        {
            _db = db;       
        }

        public List<StrucnaSprema> GetAll()
        {
            List<StrucnaSprema> lista = _db.StrucnaSprema.Select(x => x).ToList();
            return lista;
        }
    }
}
