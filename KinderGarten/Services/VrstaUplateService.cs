using KinderGarten.Data;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    public class VrstaUplateService : IVrstaInterface
    {
        private readonly KinderGartenContext _db;
        public VrstaUplateService(KinderGartenContext db)
        {
            _db = db;
        }
        public List<VrstaUplate> GetAll()
        {
            return _db.VrstaUplate.ToList();
        }
    }
}
