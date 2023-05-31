using AcademiaSoft.Dao;
using AcademiaSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaSoft.Controllers
{
    public class AlumnoController : Controller
    {
        AlumnoDao alumnodao=new AlumnoDao();
        UsuarioDao usuariodao=new UsuarioDao();

        public ActionResult Index()
        {
            try
            {
                ViewBag.delete = TempData["eliminar_mensanje"];
                ViewBag.save = TempData["registrar_mensanje"];
                ViewBag.update = TempData["actualizar_mensanje"];
            }
            catch (Exception ex) { }

            var alumnos = alumnodao.ListarAlumnos();
            var usuarios = usuariodao.ListarUsuarios();
            return View(new {alumnos, usuarios });
        }

        // GET: AlumnoController/Create
        public ActionResult Create()
        {
            ViewBag.Usuarios = usuariodao.ListarUsuarios();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                alumnodao.Guardar(alumno);
                TempData["registrar_mensanje"] = "Se Registro Correctamente";
                ViewBag.save = TempData["registrar_mensanje"];
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Usuarios = usuariodao.ListarUsuarios();
            return View(alumno);
        }


        // GET: AlumnoController/Edit/5
        public ActionResult Edit(int id)
        {
            Alumno alumno = alumnodao.Buscar(id);
            if (alumno != null)
            {   
                ViewBag.Usuarios = usuariodao.ListarUsuarios();
                return View(alumno);
            }
            return RedirectToAction(nameof(Index));
            
        }

        // POST: AlumnoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Alumno alumno)
        {
            if(ModelState.IsValid)
            {
                TempData["actualizar_mensanje"] = "Se Actualizo Correctamente.";
                ViewBag.update = TempData["actualizar_mensanje"];
                alumnodao.Actualizar(alumno);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Usuarios = usuariodao.ListarUsuarios();
            return View(alumno);
        }

        // GET: AlumnoController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Alumno alumno = alumnodao.Buscar(id);
            if (id==null || alumno==null)
            {
                return NotFound();
            }
            TempData["eliminar_mensanje"] = "Se Elimino Correctamente el Alumno.";
            ViewBag.delete = TempData["eliminar_mensanje"];
            alumnodao.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
