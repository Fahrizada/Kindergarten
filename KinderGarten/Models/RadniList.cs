using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class RadniList
    {
        [Key]
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        
        [ForeignKey("ZaposlenikPrvaSmjena")]
        public int Zaposlenik1ID { get; set; }
        public Zaposlenik ZaposlenikPrvaSmjena { get; set; }
        
        [ForeignKey("ZaposlenikDrugaSmjena")]
        public int Zaposlenik2ID { get; set; }
        public Zaposlenik ZaposlenikDrugaSmjena { get; set; }

        [ForeignKey("Grupa")]
        public int GrupaID { get; set; }
        public Grupa Grupa { get; set; }
    }
}
