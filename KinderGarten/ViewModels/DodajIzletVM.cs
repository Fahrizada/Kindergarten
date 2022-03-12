using KinderGarten.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarten.ViewModels
{
    public class DodajIzletVM
    {
        public int IzletID { get; set; }
        public DateTime DatumIzletaOd { get; set; }
        public DateTime DatumIzletaDo { get; set; }
        public string Lokacija { get; set; }
        public int ZaposlenikID { get; set; }
        public List<SelectListItem> Zaposlenici { get; set; }
    }
}
