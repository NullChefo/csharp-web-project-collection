using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApplication.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [MaxLength(50, ErrorMessage = "Invalid first name!")]
        [Required(ErrorMessage = "The field 'First name' is required!")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [MaxLength(50, ErrorMessage = "Invalid last name!")]
        [Required(ErrorMessage = "The field 'Last name' is required!")]
        public string LastName { get; set; }

        [Display(Name = "Avatar")]
        public IFormFile Avatar { get; set; }

        public string AvatarFilePath { get; set; }
    }
}
