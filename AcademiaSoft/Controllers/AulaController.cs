using AcademiaSoft.Dao;
using AcademiaSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaSoft.Controllers
{
    public class AulaController : Controller
    {
        AulaDao auladao=new AulaDao();
        public ActionResult Index()
        {
            try
            {
                ViewBag.delete = TempData["eliminar_mensanje"];
                ViewBag.save = TempData["registrar_mensanje"];
                ViewBag.update = TempData["actualizar_mensanje"];
                ViewBag.error = TempData["error_mensanje"];
            }
            catch (Exception ex) { }
            var aula=auladao.Listar();
            return View(aula);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aula aula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["registrar_mensanje"] = "Se Registro Correctamente";
                    ViewBag.save = TempData["registrar_mensanje"];
                    auladao.Guardar(aula);
                    return RedirectToAction(nameof(Index));
                }
                return View(aula);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Aula aula_existe = auladao.Buscar(id);
            if (id !=null && aula_existe != null)
            {
                return View(aula_existe);
            }
            TempData["error_mensanje"] = "El Aula no existe en el Sistema.";
            ViewBag.error = TempData["error_mensanje"];
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Aula aula)
        {
            try
            {
                Aula aula_existe = auladao.Buscar(id);
                if (id != null && aula_existe != null)
                {
                    if (ModelState.IsValid)
                    {
                        TempData["actualizar_mensanje"] = "Se Actualizo Correctamente.";
                        ViewBag.update = TempData["actualizar_mensanje"];
                        auladao.Actualizar(aula);
                        return RedirectToAction(nameof(Index));
                    }
                    return View(aula);
                }
                TempData["error_mensanje"] = "El Aula no existe en el Sistema.";
                ViewBag.error = TempData["error_mensanje"];
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Aula aula = auladao.Buscar(id);
            if (id == null || aula ==null)
            {
                return NotFound();
            }
            var mensaje = auladao.Eliminar(id);
            TempData["eliminar_mensanje"] = "" + mensaje + "";
            ViewBag.delete = TempData["eliminar_mensanje"];
            return RedirectToAction(nameof(Index));
        }

        // POST: AulaController/Delete/5
        /*
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
         */
    }
}
