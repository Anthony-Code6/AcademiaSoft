using AcademiaSoft.Dao;
using AcademiaSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaSoft.Controllers
{
    public class NotasController : Controller
    {
        MatriculaDao matriculadao = new MatriculaDao();
        public ActionResult Index()
        {
            try
            {
                ViewBag.delete = TempData["eliminar_mensanje"];
                ViewBag.save = TempData["registrar_mensanje"];
                ViewBag.update = TempData["actualizar_mensanje"];
            }
            catch (Exception ex) { }
            
            ViewBag.Matricula=matriculadao.ListarMatricula();
            
            return View();
        }

        // GET: NotasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotasController/Create
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

        // GET: NotasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotasController/Edit/5
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

        // GET: NotasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotasController/Delete/5
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
