using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class Dijete
    {
        [Key]
        public int ID { get; set; }
        
        public string JMBG  { get; set; } 
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        
        public string Napomena { get; set; }
        public bool PosebnePotrebe { get; set; }

        [ForeignKey("Grupa")]
        public int GrupaID { get; set; }
        public Grupa Grupa { get; set; }

        [ForeignKey("Roditelj")]
        public int RoditeljID { get; set; }
        public Roditelj Roditelj { get; set; }

        public string PutanjaSlike { get; set; }

    }
}
