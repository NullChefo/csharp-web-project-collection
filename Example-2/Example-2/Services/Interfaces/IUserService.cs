using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleTwo.Models;
using ExampleTwo.Models;

namespace ExampleTwo.Services
{
    public interface IUserService
    {
        public UserModel SaveStudent(UserModel model);
        public List<UserModel> GetStudents();
    }
}
