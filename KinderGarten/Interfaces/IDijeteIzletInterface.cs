using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface IDijeteIzletInterface
    {
        public List<Dijete> GetByIzlet(int IzletID);
        void Add(DijeteIzlet dijete);
        void Delete(int izletID, int dijeteID);
    }
}
