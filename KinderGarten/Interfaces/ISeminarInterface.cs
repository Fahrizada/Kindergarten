using KinderGarten.Models;
using KinderGarten.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface ISeminarInterface
    {
        List<Seminar> GetAll();
        void AddSeminar(DodajSeminarVM model);
        void ObrisiSeminar(int seminarID);
        Seminar Find(int SeminarID);
        void Update(DodajSeminarVM model);
    }
}
