using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Libro.GetAll();
            ML.Libro libro = new ML.Libro();

            if (result.Correct)
            {
                libro.Libros = result.Objects;
                return View(libro);
            }
            else
            {
                return View(libro);
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdLibro)
        {
            ML.Result result = BL.Libro.Delete(IdLibro);

            if (result.Correct)
            {
                ViewBag.message = "Se Elimino el Libro";
                return View("Modal");
            }
            else
            {
                ViewBag.message = "No se elimino el Libro";
            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            ML.Autor autor = new ML.Autor();

            if (IdLibro == null)
            {
                return View(libro);
            }
            else
            {
                ML.Result result = BL.Libro.GetById(IdLibro.Value);
                libro = (ML.Libro) result.Object;
                return View(libro);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Autor autor = new ML.Autor();

            if (libro.IdLibro == 0)
            {
                //ML.Libro libro = new ML.Libro();
                ML.Result result = BL.Libro.Add(libro);

                return View(libro);
            }
            else
            {
                //ML.Libro libro = new ML.Libro();

                //ML.Result result = BL.Libro.GetById(IdLibro);
                //result = BL.Libro.Update(libro);

                return View(libro);
            }
        }
    }
}