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
        IWorkerRepository repo;

        public HomeController(IWorkerRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(repo.GetAll());
        }

        [HttpGet]
        public IActionResult Delete(string alias)
        {
            //megkapjuk a törlendő dolgozó aliasát
            repo.Delete(alias);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modify(string alias)
        {
            var model = repo.GetWorkerByHash(alias);
            return View(model);
        }

        [HttpPost]
        public IActionResult Modify(WorkerModel model, string alias)
        {
            if (!ModelState.IsValid)
            {
                //visszadobjuk a modellt!
                return View(model);
            }
            repo.ModifyWorker(model, alias);
            return RedirectToAction("Index");
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
