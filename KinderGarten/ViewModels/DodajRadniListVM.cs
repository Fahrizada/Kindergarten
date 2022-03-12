using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace KinderGarten.ViewModels
{
    public class DodajRadniListVM
    {
        public string Datum { get; set; } = DateTime.UtcNow.ToShortDateString();
        public List<SelectListItem> Grupe { get; set; }
        public List<SelectListItem> Zaposlenici { get; set; }
        public int GrupaID { get; set; }
        public int ZaposlenikPrvaSmjenaID { get; set; }
        public int ZaposlenikDrugaSmjenaID { get; set; }
    }
}
