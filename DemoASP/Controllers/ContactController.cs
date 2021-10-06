using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoASP.Tools;
using DataAccessLayer.Entities;

namespace DemoASP.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [AuthRequired]
        public IActionResult Index()
        {
            return View(_service.GetAll(HttpContext.Session.GetUser().Token));
        }

        [AdminRequired]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact c)
        {
            _service.Insert(c, HttpContext.Session.GetUser().Token);
            return RedirectToAction("Index");
        }
    }
}
