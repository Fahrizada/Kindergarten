using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface IZaposlenikSeminarInterface
    {
        public List<ZaposlenikSeminar> GetBySeminar(int SeminarID);
        void Add(ZaposlenikSeminar zaposlenik);
        void Delete(int seminarID, int zaposlenikID);
    }
}
