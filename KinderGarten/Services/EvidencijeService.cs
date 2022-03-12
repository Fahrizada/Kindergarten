using KinderGarten.Data;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using KinderGarten.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KinderGarten.Services
{
    public class EvidencijeService : IEvidencijeService
    {
        private readonly KinderGartenContext context;
        public EvidencijeService(KinderGartenContext context)
        {
            this.context = context;
        }
        public void DodajEvidenciju(DodajEvidencijuVM model)
        {
            Evidencija nova = new Evidencija
            {
                DijeteID = model.DijeteID,
                Odlazak = model.OdlazakID,
                RoditeljID = model.RoditeljID,
                RadniListID = model.RadniListID,
                Vrijeme = model.Datum,
                ZaposlenikID = model.ZaposlenikID
            };
            context.Add(nova);
            context.SaveChanges();
        }
        public List<Evidencija> GetAll()
        {
            List<Evidencija> lista = context.Evidencija
                .Include(x => x.Dijete)
                .Include(x => x.Roditelj)
                .Include(x => x.Zaposlenik)
                .ToList();
            return lista;
        }

        public bool PromijeniStatus(int EvidencijaID)
        {
            var edited = context.Evidencija.FirstOrDefault(a => a.ID == EvidencijaID);
            if (edited == null)
                return false;

            edited.Odlazak = !edited.Odlazak;
            context.Update(edited);
            context.SaveChanges();
            return true;
        }
    }
}
