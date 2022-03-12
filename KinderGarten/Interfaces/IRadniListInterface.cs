using KinderGarten.Models;
using KinderGarten.ViewModels;
using System.Collections.Generic;

namespace KinderGarten.Interfaces
{
    public interface IRadniListInterface
    {
        List<RadniList> GetAll();
        void AddRadniList(DodajRadniListVM model);
    }
}
