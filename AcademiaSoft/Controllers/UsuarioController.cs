using AcademiaSoft.Dao;
using AcademiaSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaSoft.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDao usuariodao = new UsuarioDao();

        public ActionResult Index()
        {
            try
            {
                ViewBag.error = TempData["eliminar_mesnaje"];
                ViewBag.save = TempData["registrar_mesnaje"];
                ViewBag.update = TempData["actualizar_mesnaje"];
            }
            catch (Exception ex) { }
            var usuario=usuariodao.ListarUsuarios();
            return View(usuario);
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
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuariodao.Guardar(usuario);
                TempData["registrar_mesnaje"] = "Se Registro Correctamente";
                ViewBag.save = TempData["registrar_mesnaje"];
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public ActionResult Edit(int id)
        {
            Usuario usuario=usuariodao.Buscar(id);
            if (usuario != null && id!=null)
            {
                return View(usuario);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Usuario usuario)
        {
            Usuario user=usuariodao.Buscar(Id);
            if (user != null && Id!=null)
            {
                if (ModelState.IsValid)
                {
                    TempData["actualizar_mesnaje"] = "Se Actualizo Correctamente.";
                    ViewBag.update = TempData["actualizar_mesnaje"];
                    usuariodao.Actualizar(usuario);
                    return RedirectToAction(nameof(Index));
                }
                return View(usuario);
            }
            return NotFound();
            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Usuario user = usuariodao.Buscar(id);
            if (user != null && id != null)
            {
                TempData["eliminar_mesnaje"] = "Se Elimino Correctamente el Alumno.";
                ViewBag.error = TempData["eliminar_mesnaje"];
                usuariodao.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        
    }
}
