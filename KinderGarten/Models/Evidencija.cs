using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class Evidencija
    {
        [Key]
        public int ID { get; set; }
        public DateTime Vrijeme { get; set; }
        public bool Odlazak { get; set; }
        //default = false 

        [ForeignKey("Zaposlenik")]
        public int ZaposlenikID { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        [ForeignKey("RadniList")]
        public int RadniListID { get; set; }
        public RadniList RadniList { get; set; }

        [ForeignKey("Roditelj")]
        public int RoditeljID { get; set; }
        public Roditelj Roditelj { get; set; }

        [ForeignKey("Dijete")]
        public int DijeteID { get; set; }
        public Dijete Dijete { get; set; }
    }
}
