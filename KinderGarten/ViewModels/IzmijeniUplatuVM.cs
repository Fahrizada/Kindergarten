using KinderGarten.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class IzmijeniUplatuVM
    {
        public Uplata Uplata { get; set; }
        public List<SelectListItem> Roditelj { get; set; }
        public int RoditeljID { get; set; }
        public List<SelectListItem> Dijete { get; set; }
        public int DijeteID { get; set; }
        public List<SelectListItem> VrstaUplate { get; set; }
        public int VrstaUplateID { get; set; }
    }
}
