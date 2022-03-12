using KinderGarten.Data;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    public class UplataService : IUplataInterface
    {
        private readonly KinderGartenContext _db;
        public UplataService(KinderGartenContext db)
        {
            _db = db;
        }
        public  List<Uplata> GetAll()
        {
            return _db.Uplata.Include(o => o.Roditelj).Include(o => o.Dijete).Include(o => o.VrstaUplate).ToList();
        }
        public List<Uplata> GetAllbyEmail(string email)
        {
            return _db.Uplata.Include(o => o.Roditelj).Include(o => o.Dijete).Include(o => o.VrstaUplate).
                Where(o => o.Roditelj.Email == email).ToList();
        }
        public void AddUplatu(DodajUplatuVM model)
        {
            Uplata uplata = new Uplata
            {
                DatumUplate = model.DatumUplate,
                VrstaUplateID = model.VrstaUplateID,
                RoditeljID = model.RoditeljID,
                Iznos = model.Iznos,
                DijeteID = model.DijeteID
            };
            _db.Uplata.Add(uplata);
            _db.SaveChanges();
        }
        public void ObrisiUplatu(int UplataID)
        {
            Uplata uplata = _db.Uplata.Find(UplataID);
            _db.Uplata.Remove(uplata);
            _db.SaveChanges();
        }
        public Uplata FindByID(int UplataID)
        {
            return _db.Uplata.Include(o => o.Roditelj).Include(o => o.Dijete).Include(o => o.VrstaUplate).Where
                (o => o.ID == UplataID).FirstOrDefault();
        }
        public void Update(Uplata uplata)
        {
            _db.Uplata.Update(uplata);
            _db.SaveChanges();
        }

    }
}
