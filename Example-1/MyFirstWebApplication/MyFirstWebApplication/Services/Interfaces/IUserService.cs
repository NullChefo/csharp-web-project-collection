using MyFirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApplication.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserModel> GetAll();
        public UserModel Add(UserModel user);

        public UserModel Get(int id);
    }
}
