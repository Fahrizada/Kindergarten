using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarten.ViewModels
{
    public class DjecaGrupaVM
    {
        public int DijeteID { get; set; }
        public string DijeteImePrezime { get; set; }
        public bool? Dolazak { get; set; }
        public List<SelectListItem> OvlasteneOsobeDijete { get; set; }
        public int OvlastenaOsobaID { get; set; }
    }
}
