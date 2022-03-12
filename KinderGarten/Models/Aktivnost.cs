using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Models
{
    public class Aktivnost
    {
        [Key]
        public int ID { get; set; }
        public string OpisAktivnosti { get; set; }
        public string NazivAktivnosti { get; set; }
        public DateTime DatumAktivnosti { get; set; }
    }
}
