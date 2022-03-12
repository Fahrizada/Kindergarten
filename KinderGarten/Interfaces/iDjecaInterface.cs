using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KinderGarten.Interfaces
{
    public interface IDjecaInterface
    {
        List<Dijete> GetAll();
        int AddDijete(DodajDijeteVM model, IFormFile slika);
        void ObrisiDijete(int dijeteID);
        void SacuvajDijete(DodajDijeteVM model);
        bool IzmijeniSliku(int id, string putanja);

    }
}
