using AcademiaSoft.Dao;
using AcademiaSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaSoft.Controllers
{
    public class BoletaNotasController : Controller
    {
        BoletaNotasDao boletaNotasDao = new BoletaNotasDao();


        // GET: BoletaNotasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BoletaNotasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BoletaNotasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoletaNotasController/Create
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

        // GET: BoletaNotasController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id != null || id>0)
            {
                ViewBag.Notas = boletaNotasDao.Listar(id);
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: BoletaNotasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BoletaNotasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BoletaNotasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
