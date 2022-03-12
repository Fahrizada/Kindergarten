using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class DijeteIzlet
    {
        [ForeignKey("Dijete")]
        public int DijeteID { get; set; }
        public Dijete Dijete { get; set; }

        [ForeignKey("Izlet")]
        public int IzletID { get; set; }
        public Izlet Izlet { get; set; }
    }
}
