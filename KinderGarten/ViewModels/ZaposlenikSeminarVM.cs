using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class ZaposlenikSeminarVM
    {
        public Seminar Seminar { get; set; }
        public List<Zaposlenik> Zaposlenici { get; set; }
        public List<ZaposlenikSeminar> ZaposlenikSeminar { get; set; }

    }
}
