using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KinderGarten.Interfaces
{
    public interface IOvlastenaOsobaInterface
    {
        List<OvlastenaOsoba> GetAll();
        List<OvlastenaOsoba> GetByDijeteID(int DijeteID);
        void AddOvlastenaOsoba(DodajOvlastenuOsobuVM model, IFormFile slika);
        void ObrisiOvlastenaOsoba(int OvlastenaOsobaID);
        void SacuvajOvlastenaOsoba(DodajOvlastenuOsobuVM model);
        bool IzmijeniSliku(int id, string putanja);

    }
}
