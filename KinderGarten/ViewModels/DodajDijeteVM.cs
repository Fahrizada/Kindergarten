using KinderGarten.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinderGarten.ViewModels
{
    public class DodajDijeteVM
    {
        public int ID { get; set; }
      
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Napomena { get; set; }
        public bool PosebnePotrebe { get; set; }
        public List<SelectListItem> Roditelj { get; set; }
        public int RoditeljID { get; set; }
        public List<SelectListItem> Grupe { get; set; }
        public int GrupaID { get; set; }
    }
}
