using KinderGarten.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class DodajDjecuNaIzletVM
    {
        public List<SelectListItem> Djeca { get; set; }
        public int IzletID { get; set; }
        [Display(Name = "Dodaj dijete")]
        public int[] DodavanjaIDs { get; set; }
    }
}
