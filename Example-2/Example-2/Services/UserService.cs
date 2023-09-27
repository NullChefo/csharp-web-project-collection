using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleTwo.Data;
using ExampleTwo.Data.Models;
using ExampleTwo.Models;
using ExampleTwo.Data;
using ExampleTwo.Data.Models;
using ExampleTwo.Models;

namespace ExampleTwo.Services
{
    public class UserService : IUserService
    {
        private readonly MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public List<UserModel> GetStudents()
        {
            return _context.Users
                .Select(user => new UserModel()
                {
                    Id = user.Id,
                    Age = user.Age,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    FacultyNumber = user.FacultyNumber
                }).ToList();
        }

        public UserModel SaveStudent(UserModel model)
        {
            Users user = new Users()
            {
                //Age = model.Age.HasValue ? model.Age.Value : 0,
                Age = model.Age ?? 0,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                FacultyNumber = model.FacultyNumber
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            model.Id = user.Id;
            return model;
        }
    }
}
