using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Models
{
    public class DijeteAktivnost
    {
       

        [ForeignKey("Dijete")]
        public int DijeteID { get; set; }
        public Dijete Dijete { get; set; }

        [ForeignKey("Aktivnost")]
        public int AktivnostID { get; set; }
        public Aktivnost Aktivnost { get; set; }
    }
}
