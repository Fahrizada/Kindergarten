using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarten.ViewModels
{
    public class DetaljiRadniListVM
    {
        public int RadniListID { get; set; }
        public string Datum { get; set; }
        public string Grupa { get; set; }
        public int GrupaID { get; set; }
        public string Zaposlenik1 { get; set; }
        public string Zaposlenik2 { get; set; }
    }
}
