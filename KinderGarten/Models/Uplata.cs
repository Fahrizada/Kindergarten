using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class Uplata
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumUplate { get; set; }
        public decimal Iznos { get; set; }

        [ForeignKey("Dijete")]
        public int DijeteID { get; set; }
        public Dijete Dijete { get; set; }

        [ForeignKey("Roditelj")]
        public int RoditeljID { get; set; }
        public Roditelj Roditelj { get; set; }

        [ForeignKey("VrstaUplate")]
        public int VrstaUplateID { get; set; }
        public VrstaUplate VrstaUplate { get; set; }
    }
}
