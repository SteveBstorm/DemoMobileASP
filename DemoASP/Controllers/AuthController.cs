using DataAccessLayer.Repositories;
using DemoASP.Models;
using DemoASP.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASP.Controllers
{
    public class AuthController : Controller
    {
        private IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            User currentUser = _service.Login(form.Email, form.Password).ToASP();

            HttpContext.Session.SetUser(currentUser);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            _service.Login(form.Email, form.Password);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Disconnect()
        {
            HttpContext.Session.Disconnect();
            return RedirectToAction("Index", "Home");
        }
    }
}
