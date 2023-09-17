using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApplication.Data;
using MyFirstWebApplication.Models;
using MyFirstWebApplication.Services.Interfaces;

namespace MyFirstWebApplication.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<UserModel> model = _userService.GetAll();
                return View(model);
            }
            catch (Exception ex)
            {
                //TODO: Log data in file or DB
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            try
            {
                return View(_userService.Get(id));
            }
            catch (Exception ex)
            {
                //TODO: Log data in file or DB
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                _userService.Add(model);
            }
            catch (Exception ex)
            {
                //TODO: Log data in file or DB
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}
