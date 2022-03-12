using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface IIzletZaposleniciInterface
    {
        public List<IzletZaposlenici> GetByIzlet(int IzletID);
        void Add(IzletZaposlenici zaposlenik);
        void Delete(int izletID, int zaposlenikID);
    }
}
