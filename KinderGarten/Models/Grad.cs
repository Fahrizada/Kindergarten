using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class Grad
    {
        [Key]
        public int  ID { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        [ForeignKey("Drzava")]
        public int DrzavaID { get; set; }
        public Drzava Drzava { get; set; }
    }
}
