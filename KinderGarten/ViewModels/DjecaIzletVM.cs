using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class DjecaIzletVM
    {
        public Izlet Izlet { get; set; }
        public List<Dijete> Djeca { get; set; }
        public List<DijeteIzlet> DjecaIzlet { get; set; }
        public List<IzletZaposlenici> IzletZaposlenici { get; set; }


    }
}