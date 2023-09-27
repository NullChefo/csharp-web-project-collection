using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleTwo.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "Години")]
        public int? Age { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Полето 'Име' е задължително!")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Полето 'Фамилия' е задължително!")]
        public string LastName { get; set; }

        [Display(Name = "Дата на раждане")]
        [Required(ErrorMessage = "Полето 'Дата на раждане' е задължително!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Факултетен номер")]
        [Required(ErrorMessage = "Полето 'Факултетен номер' е задължително!")]
        public string FacultyNumber { get; set; }
    }
}
