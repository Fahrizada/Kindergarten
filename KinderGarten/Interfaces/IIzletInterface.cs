using System;
using System.Collections.Generic;
using System.Text;
using KinderGarten.Models;
using KinderGarten.ViewModels;

namespace KinderGarten.Interfaces
{
    public interface IIzletInterface
    {
        public Izlet Find(int IzletID);
        List<Izlet> GetAll();
        void Add(DodajIzletVM model);
        void Delete(int IzletID);
        void Update(DodajIzletVM model);
    }
}

