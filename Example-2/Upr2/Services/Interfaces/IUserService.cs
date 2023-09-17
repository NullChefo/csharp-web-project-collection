using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upr2.Models;

namespace Upr2.Services
{
    public interface IUserService
    {
        public UserModel SaveStudent(UserModel model);
        public List<UserModel> GetStudents();
    }
}
