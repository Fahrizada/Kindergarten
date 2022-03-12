using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class DijeteOvlastenaOsoba
    {
        [ForeignKey("Dijete")]
        public int DijeteID { get; set; }
        public Dijete Dijete { get; set; }

        [ForeignKey("OvlastenaOsoba")]
        public int OvlastenaOsobaID { get; set; }
        public OvlastenaOsoba OvlastenaOsoba { get; set; }
    }
}
