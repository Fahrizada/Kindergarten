using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
     public interface IRoditeljInterface
    {
        List<Roditelj> GetAll();
        void AddRoditelj(Roditelj model, IFormFile slika);
        void ObrisiRoditelja(int RoditeljID);
        Roditelj FindRoditeljByID(int RoditeljID);
        Roditelj FindRoditeljByEmail(string Email);
        void Update(Roditelj model);
        bool IzmijeniSliku(int id, string putanja);

    }
}
