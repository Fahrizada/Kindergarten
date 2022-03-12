using KinderGarten.Models;
using KinderGarten.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarten.Interfaces
{
    public interface IGradInterface
    {
        List<Grad> GetAll();
        void AddGrad(DodajGradVM grad);
        void DeleteGrad(int id);
        void SacuvajGrad(DodajGradVM model);
        void DodajGrad(Grad grad);
    }
}
