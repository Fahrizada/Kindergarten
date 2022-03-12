using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace KinderGarten.ViewModels
{
    public class DodajZaposlenikaVM
    {
        public int ID { get; set; }
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public bool Zaposlen { get; set; }
        public bool Aktivan { get; set; }
        public List<SelectListItem> StrucnaSprema { get; set; }
        public int StrucnaSpremaID { get; set; }
        public List<SelectListItem> Zanimanje { get; set; }
        public int ZanimanjeID { get; set; }

    }
}
