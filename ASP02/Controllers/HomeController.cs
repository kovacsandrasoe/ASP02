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
        public IActionResult Delete(int hashcode)
        {
            //megkapjuk a törlendő dolgozó hashcode-ját
            repo.Delete(hashcode);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modify(int hashcode)
        {
            var model = repo.GetWorkerByHash(hashcode);
            return View(model);
        }

        [HttpPost]
        public IActionResult Modify(WorkerModel model, int hash)
        {
            if (!ModelState.IsValid)
            {
                //visszadobjuk a modellt!
                return View(model);
            }
            repo.ModifyWorker(model, hash);
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
