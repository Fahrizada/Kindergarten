using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class OvlastenaOsoba
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
        public bool Zaposlen { get; set; }
        public bool Aktivan { get; set; }

        [ForeignKey("StrucnaSprema")]
        public int StrucnaSpremaID { get; set; }
        public StrucnaSprema StrucnaSprema { get; set; }
        public string PutanjaSlike { get; set; }

    }
}
