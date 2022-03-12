using KinderGarten.Models;
using KinderGarten.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface IUplataInterface
    {
        List<Uplata> GetAll();
        void AddUplatu(DodajUplatuVM model);
        void ObrisiUplatu(int UplataID);
        Uplata FindByID(int UplataID);
        void Update(Uplata uplata);
        List<Uplata> GetAllbyEmail(string email);
    }
}
