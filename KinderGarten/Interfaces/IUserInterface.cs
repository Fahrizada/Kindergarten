using System.Collections.Generic;
using KinderGarten.Models;
using Microsoft.AspNetCore.Identity;

namespace KinderGarten.Interfaces
{
    public interface IUserInterface
    {
        List<User> GetAll();
        void DeleteUser(string UserID);
        void SaveUser(User user, IdentityUserClaim<string> claim);
        User FindByEmail(string email);
        User FindByID(string UserID);
    }
}
