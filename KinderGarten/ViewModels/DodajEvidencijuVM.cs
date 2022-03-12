using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace KinderGarten.ViewModels
{
    public class DodajEvidencijuVM
    {
        public DateTime Datum { get; set; }
        public bool OdlazakID { get; set; }
        public int RadniListID { get; set; }
        public int RoditeljID { get; set; }
        public int DijeteID { get; set; }
        public int ZaposlenikID { get; set; }
        public List<SelectListItem> Roditelji { get; set; }
        public List<SelectListItem> Djeca { get; set; }
        public List<SelectListItem> Zaposlenici { get; set; }
        public List<SelectListItem> Odlazak { get; set; } = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text="Odlazak",
                Value=false.ToString()
            },
            new SelectListItem
            {
                Text="Dolazak",
                Value=true.ToString()
            }
        };
    }
}
