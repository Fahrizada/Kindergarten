using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Models
{
    public class IzletZaposlenici
    {
        public int IzletID { get; set; }
        [ForeignKey(nameof(IzletID))]
        public Izlet Izlet { get; set; }

        public int ZaposlenikID { get; set; }
        [ForeignKey(nameof(ZaposlenikID))]
        public Zaposlenik Zaposlenik { get; set; }
    }
}
