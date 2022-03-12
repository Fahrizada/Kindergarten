using KinderGarten.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarten.Interfaces
{
    public interface IDrzavaInterface
    {
        List<Drzava> GetAll();
        void AddDrzava(Drzava drzava);
        void RemoveDrzava(int drzavaID);
        void SacuvajDrzavu(Drzava drzava);
        Drzava GetByName(string name);
    }
}
