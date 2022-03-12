using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class Izlet
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumIzletaOd { get; set; }
        public DateTime DatumIzletaDo { get; set; }
        public string Lokacija { get; set; }

    }
}
