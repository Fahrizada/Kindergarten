using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class DodajSeminarVM
    {
        public int SeminarID { get; set; }
        public string NazivSeminara { get; set; }
        public string Adresa { get; set; }
        public DateTime VrijemeSeminaraOd { get; set; }
        public DateTime VrijemeSeminaraDo { get; set; }
        public bool Certifikat { get; set; }
        public List<SelectListItem> Gradovi { get; set; }
        public int GradID { get; set; }
    }
}
