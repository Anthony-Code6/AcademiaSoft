using AcademiaSoft.Dao;
using AcademiaSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaSoft.Controllers
{
    public class BoletaNotasController : Controller
    {
        BoletaNotasDao boletaNotasDao = new BoletaNotasDao();
        AlumnoDao alumnoDao = new AlumnoDao();
        AulaDao aulaDao = new AulaDao();
        MatriculaDao matriculaDao = new MatriculaDao();

        CargoProfesorDao cargoProfesorDao = new CargoProfesorDao();
        CursoDao cursoDao = new CursoDao();
        ProfesorDao ProfesorDao = new ProfesorDao();

        // GET: BoletaNotasController
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
        public ActionResult Create([FromBody] BoletaNotas boleta)
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
                

                if (ViewBag.Notas.Count > 0)
                {
                    ViewBag.CargoProfesor = cargoProfesorDao.Listar();
                    ViewBag.Curso=cursoDao.ListarCurso();
                    ViewBag.Matricula = matriculaDao.ListarAlumnoMatricula();
                    ViewBag.Alumno = alumnoDao.ListarAlumnos();
                    ViewBag.Profesor=ProfesorDao.ListarProfesor();

                    foreach (var boleta in ViewBag.Notas)
                    {
                        foreach (var cargo in ViewBag.CargoProfesor)
                        {
                            if (boleta.Idcargo == cargo.Id)
                            {
                                foreach (var curso in ViewBag.Curso)
                                {
                                    if (cargo.Idcurso == curso.Id)
                                    {
                                        ViewBag.Titulo = curso.Descripcion;
                                    }
                                }

                                foreach (var profesor in ViewBag.Profesor)
                                {
                                    if (cargo.Idprofesor == profesor.Id)
                                    {
                                        ViewBag.Docente = profesor.Apellido + " "+profesor.Nombre;
                                    }
                                }
                            }
                        }
                    }

                    return View();
                }
                TempData["error_mensanje"] = "Error no existe una boleta de nota";
                ViewBag.error = TempData["error_mensanje"];
                return RedirectToAction(nameof(Index));
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
