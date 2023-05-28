using AcademiaSoft.Dao;
using AcademiaSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaSoft.Controllers
{
    public class PeriodoController : Controller
    {
        PeriodoDao periododao =new PeriodoDao();
        public ActionResult Index()
        {
            try
            {
                ViewBag.delete = TempData["eliminar_mesnaje"];
                ViewBag.save = TempData["registrar_mesnaje"];
                ViewBag.update = TempData["actualizar_mesnaje"];
            }
            catch (Exception ex) { }
            return View(periododao.Listar());
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
        public ActionResult Create(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                periododao.Guardar(periodo);
                TempData["registrar_mesnaje"] = "Se Registro Correctamente";
                ViewBag.save = TempData["registrar_mesnaje"];
                return RedirectToAction(nameof(Index));
            }
            return View(periodo);
        }

        public ActionResult Edit(int id)
        {
            Periodo periodo=periododao.Buscar(id);
            if (id !=null && periodo!= null)
            {
                return View(periodo);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Periodo periodo)
        {
            Periodo Validar_Periodo = periododao.Buscar(id);
            if (Validar_Periodo != null)
            {
                if (ModelState.IsValid)
                {
                    TempData["actualizar_mesnaje"] = "Se Actualizo Correctamente.";
                    ViewBag.update = TempData["actualizar_mesnaje"];
                    periododao.Actualizar(periodo);
                    return RedirectToAction(nameof(Index));
                }
                return View(periodo);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Periodo periodo = periododao.Buscar(id);
            if (id != null && periodo != null)
            {
                var mensaje= periododao.Eliminar(id);
                TempData["eliminar_mesnaje"] = ""+mensaje+"";
                ViewBag.delete = TempData["eliminar_mesnaje"];
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        
    }
}
