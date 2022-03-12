using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Models
{
    public class StrucnaSprema
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
