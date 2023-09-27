using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleTwo.Models;
using ExampleTwo.Services;
using Microsoft.AspNetCore.Mvc;
using ExampleTwo.Models;
using ExampleTwo.Services;

namespace ExampleTwo.Controllers
{
    public class FormController : Controller
    {
        private readonly IUserService _userService;

        public FormController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = _userService.GetStudents();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public IActionResult Add(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                if (!model.Age.HasValue || model.Age <= 0)
                {
                    model.Age = (int)Math.Floor((DateTime.Now - model.BirthDate)
                        .TotalDays / 365);
                }

                _userService.SaveStudent(model);
                return RedirectToAction("Index");
            }
        }
    }
}
