using KinderGarten.Models;
using KinderGarten.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface IAktivnostInterface
    {
        List<Aktivnost> GetAll();
        void Add(Aktivnost model);
        void Delete(int AktivnostID);
        Aktivnost Find(int AktivnostID);
        void Update(Aktivnost model);
    }
}
