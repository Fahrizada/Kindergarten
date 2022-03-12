using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class AktivnostZaposlenik
    {
        [ForeignKey("Zaposlenik")]
        public int ZaposlenikID { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        [ForeignKey("Aktivnost")]
        public int AktivnostID { get; set; }
        public Aktivnost Aktivnost { get; set; }
    }
}
