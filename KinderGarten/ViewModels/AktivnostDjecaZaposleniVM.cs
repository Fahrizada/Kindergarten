using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class AktivnostDjecaZaposleniVM
    {
        public Aktivnost Aktivnost { get; set; }
        public List<Dijete> Djeca { get; set; }
        public List<DijeteAktivnost> DjecaAktivnost { get; set; }
        public List<Zaposlenik> Zaposlenik { get; set; }
        public List<AktivnostZaposlenik> ZaposlenikAktivnost { get; set; }
    }
}
