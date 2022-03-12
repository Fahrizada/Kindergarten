using System.ComponentModel.DataAnnotations;

namespace KinderGarten.Models
{
    public class VrstaUplate
    {
        [Key]
        public int ID { get; set; }
        public string Vrsta { get; set; }
    }
}
