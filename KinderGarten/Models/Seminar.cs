using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class Seminar
    {
        [Key]
        public int ID { get; set; }
        public string NazivSeminara { get; set; }
        public string Adresa { get; set; }
        public DateTime VrijemeSeminaraOd { get; set; }
        public DateTime VrijemeSeminaraDo { get; set; }
        public bool Certifikat { get; set; }

        [ForeignKey("Grad")]
        public int GradID { get; set; }
        public Grad Grad { get; set; }
    }
}
