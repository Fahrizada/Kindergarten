using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace KinderGarten.Interfaces
{
    public interface IZaposlenikInterface
    {
        List<Zaposlenik> GetAll();
        void AddZaposlenik(DodajZaposlenikaVM model, IFormFile slika);
        void ObrisiZaposlenika(int ZaposlenikID);
        void SacuvajZaposlenika(DodajZaposlenikaVM model);
        Zaposlenik FindZaposlenikByEmail(string Email);
        bool IzmijeniSliku(int id, string putanja);
        Zaposlenik FindZaposlenikByID(int ZaposlenikID);
    }
}
