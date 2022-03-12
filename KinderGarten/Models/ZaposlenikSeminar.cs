using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGarten.Models
{
    public class ZaposlenikSeminar
    {
        [ForeignKey("Zaposlenik")]
        public int ZaposlenikID { get; set; }
        public Zaposlenik Zaposlenik { get; set; }

        [ForeignKey("Seminar")]
        public int SeminarID { get; set; }
        public Seminar Seminar { get; set; }
    }
}
