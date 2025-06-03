using Microsoft.AspNetCore.Mvc;
using MovieStore.Contracts;
using MovieStore.Models;

namespace LabMvcApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        // Action-Methoden folgen...
        // GET: CinemaController
        public ActionResult Index()
        {
            var result = _service.GetCinemas();
            return View(result);
        }

        // GET: CinemaController/Details/5
        public ActionResult Details(int id)
        {
            var result = _service.GetById(id);
            return View(result);
        }

        // GET: CinemaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CinemaController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _service.GetById(id);
            return View(result);
        }

        // POST: CinemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cinema model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.UpdateCinema(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to update cinema.");
            }
            return View();
        }

        // GET: CinemaController/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _service.GetById(id);
                if (result != null)
                {
                    _service.RemoveCinema(result);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete cinema");
            }
            return View();
        }
    }
}