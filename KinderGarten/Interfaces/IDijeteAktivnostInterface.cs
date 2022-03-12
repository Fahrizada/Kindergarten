using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface IDijeteAktivnostInterface
    {
        List<DijeteAktivnost> GetByAktivnost(int AktivnostID);
        void Add(DijeteAktivnost dijete);
        void Delete(int aktivnostID, int dijeteID);
    }
}
