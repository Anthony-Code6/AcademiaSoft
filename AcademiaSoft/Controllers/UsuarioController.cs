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
                ViewBag.delete = TempData["eliminar_mensanje"];
                ViewBag.save = TempData["registrar_mensanje"];
                ViewBag.update = TempData["actualizar_mensanje"];
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
                TempData["registrar_mensanje"] = "Se Registro Correctamente";
                ViewBag.save = TempData["registrar_mensanje"];
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
                    TempData["actualizar_mensanje"] = "Se Actualizo Correctamente.";
                    ViewBag.update = TempData["actualizar_mensanje"];
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
                TempData["eliminar_mensanje"] = "Se Elimino Correctamente el Alumno.";
                ViewBag.delete = TempData["eliminar_mensanje"];
                usuariodao.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        
    }
}
