using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KinderGarten.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Role { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
    }
}
