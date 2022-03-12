using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.ViewModels
{
    public class DodajAktivnostVM
    {
        public int AktivnostID { get; set; }
        public string OpisAktivnosti { get; set; }
        public string NazivAktivnosti { get; set; }
        public DateTime DatumAktivnosti { get; set; }
        

    }
}
