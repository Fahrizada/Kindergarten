using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class DodajZaposlenikaSeminarVM
    {
        public List<SelectListItem> Zaposlenici { get; set; }
        public int SeminarID { get; set; }
        [Display(Name = "Dodaj zaposlenike")]
        public int[] DodavanjaIDs { get; set; }
    }
}
