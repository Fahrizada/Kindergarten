using KinderGarten.Models;
using KinderGarten.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace KinderGarten.Interfaces
{
    public interface IEvidencijeService
    {
        List<Evidencija> GetAll();
        void DodajEvidenciju(DodajEvidencijuVM model);
        bool PromijeniStatus(int EvidencijaID);
    }
}
