using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class Zaposlenik
    {
        [Key]
        public int ID { get; set; }
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }

        [ForeignKey("Zanimanje")]
        public int ZanimanjeID { get; set; }
        public Zanimanje Zanimanje { get; set; }

        [ForeignKey("StrucnaSprema")]
        public int StrucnaSpremaID { get; set; }
        public StrucnaSprema StrucnaSprema { get; set; }
        public string PutanjaSlike { get; set; }

    }
}
