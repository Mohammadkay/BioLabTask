using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetUserByEmail(string Email);
        List<User> GetAllUsers();
        void AddNewUser(User user);
        void RemoveUser(long userid);
    }
}
