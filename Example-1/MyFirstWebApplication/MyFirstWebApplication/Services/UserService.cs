using MyFirstWebApplication.Data;
using MyFirstWebApplication.Models;
using MyFirstWebApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApplication.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _dbContext;

        public UserService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel Add(UserModel user)
        {
            if(user.Avatar != null && user.Avatar.Length > 0)
            {
                UploadAvatar(user);
            }

            Users u = new Users()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarFilePath = user.AvatarFilePath
            };

            _dbContext.Users.Add(u);
            _dbContext.SaveChanges();
            user.Id = u.Id;

            return user;
        }

        public UserModel Get(int id)
        {
            Users user = _dbContext.Users
                .FirstOrDefault(u => u.Id == id);

            return new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarFilePath = user.AvatarFilePath
            };
        }

        public List<UserModel> GetAll()
        {
            //List<Users> users = _dbContext.Users.ToList();

            //List<UserModel> result = new List<UserModel>();
            //foreach(Users u in users)
            //{
            //    result.Add(new UserModel()
            //    {
            //        FirstName = u.FirstName,
            //        LastName = u.LastName,
            //        Id = u.Id
            //    });
            //}
            List<UserModel> users = _dbContext.Users
                .Select(u => new UserModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    AvatarFilePath = u.AvatarFilePath
                }).ToList();

            return users;
        }

        private void UploadAvatar(UserModel userModel)
        {
            //$"test 123 {var} asd"
            //var ?? "test";
            string fileName = Guid.NewGuid().ToString();
            string extension = userModel.Avatar
                .FileName.Split(".").LastOrDefault() ?? string.Empty;
            fileName += "." + extension;

            string avatarFilePath = Path.Combine("avatars", fileName);
            string pathToSave = Path.Combine("wwwroot", avatarFilePath);

            using FileStream fs = new FileStream(pathToSave,
                FileMode.Create,
                FileAccess.Write);

            userModel.Avatar.CopyTo(fs);
            userModel.AvatarFilePath = avatarFilePath;
        }
    }
}
