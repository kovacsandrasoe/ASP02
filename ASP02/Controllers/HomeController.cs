using ASP02.Data;
using ASP02.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP02.Controllers
{
    public class HomeController : Controller
    {
        WorkerXMLRepository repo;

        public HomeController(WorkerXMLRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(repo.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(WorkerModel model)
        {
            repo.Add(model);
            return RedirectToAction("Index");
        }
    }
}
