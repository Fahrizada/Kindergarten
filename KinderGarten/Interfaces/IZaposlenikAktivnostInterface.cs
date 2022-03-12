using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface IZaposlenikAktivnostInterface
    {
        List<AktivnostZaposlenik> GetByAktivnost(int AktivnostID);
        void Add(AktivnostZaposlenik zaposlenik);
        void Delete(int aktivnostID, int zaposlenikID);
    }
}
