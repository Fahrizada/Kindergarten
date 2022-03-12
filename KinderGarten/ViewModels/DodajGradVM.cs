using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace KinderGarten.ViewModels
{
    public class DodajGradVM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string PostasnkiBroj { get; set; }
        public List<SelectListItem> Drzave { get; set; }
        public int DrzavaID { get; set; }
    }
}
