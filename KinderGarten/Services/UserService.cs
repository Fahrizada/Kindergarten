using KinderGarten.Data;
using KinderGarten.Interfaces;
using KinderGarten.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    public class UserService : IUserInterface
    {
        private readonly KinderGartenContext _db;

        public UserService(KinderGartenContext db)
        {
            _db = db;
        }

        public List<User> GetAll()
        {
            return _db.User.ToList();
        }

        public void SaveUser(User user, IdentityUserClaim<string> claim)
        {
            _db.User.Add(user);
            _db.SaveChanges();

            claim.UserId = user.Id;
            _db.UserClaims.Add(claim);
            _db.SaveChanges();
        }
        public void DeleteUser(string UserID)
        {
            User u = _db.User.Find(UserID);
            _db.User.Remove(u);
            _db.SaveChanges();
        }
        public User FindByEmail(string email)
        {
            var user = _db.User.Where(o => o.Email == email).FirstOrDefault();
            return user;
        }
        public User FindByID(string UserID)
        {
            var user = _db.User.Find(UserID);
            return user;
        }
    }
}
