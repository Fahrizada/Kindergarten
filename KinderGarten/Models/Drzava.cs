using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Models
{
    public class Drzava
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
