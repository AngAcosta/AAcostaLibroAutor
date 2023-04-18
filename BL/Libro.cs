using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL.AAcostaLibroAutorEntities context = new DL.AAcostaLibroAutorEntities())
                {
                    var query = context.LibroAdd(libro.Nombre, libro.FechaPublicacion,libro.NumeroPaginas,libro.Autor.IdAutor);

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Mesagge = "Libro Agregado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Mesagge = "Libro No Agregado";
                    }
                }
            }
            catch (Exception ex) 
            {
                result.Correct = false;
                result.Mesagge = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaLibroAutorEntities context = new DL.AAcostaLibroAutorEntities())
                {
                    var query = context.LibroUpdate(libro.IdLibro,libro.Nombre, libro.FechaPublicacion, libro.NumeroPaginas, libro.Autor.IdAutor);

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Mesagge = "Libro Modificado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Mesagge = "Libro No Modificado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Mesagge = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaLibroAutorEntities context = new DL.AAcostaLibroAutorEntities())
                {
                    var query = context.LibroDelete(IdLibro);

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Mesagge = "Libro Eliminado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Mesagge = "Libro No Eliminado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Mesagge = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaLibroAutorEntities context = new DL.AAcostaLibroAutorEntities())
                {
                    var query = context.LibroGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = obj.IdLibro;
                            libro.Nombre = obj.Nombre;
                            libro.FechaPublicacion = obj.FechaPublicacion.ToString();
                            libro.NumeroPaginas = obj.NumeroPaginas;

                            libro.Autor = new  ML.Autor();
                            libro.Autor.IdAutor = obj.IdAutor.Value;
                            libro.Autor.NombreAutor = obj.NombreAutor;
                            libro.Autor.ApellidoPaterno = obj.ApellidoPaterno;
                            libro.Autor.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(libro);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Mesagge = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaLibroAutorEntities context = new DL.AAcostaLibroAutorEntities())
                {
                    var query = context.LibroGetById(IdLibro).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = query.IdLibro;
                        libro.Nombre = query.Nombre;
                        libro.FechaPublicacion = query.FechaPublicacion.ToString();
                        libro.NumeroPaginas = query.NumeroPaginas;

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = query.IdAutor.Value;
                        libro.Autor.NombreAutor = query.NombreAutor;
                        libro.Autor.ApellidoPaterno = query.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = query.ApellidoMaterno;

                        result.Object = libro;
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Mesagge = ex.Message;
            }  
            return result;
        }
    }
}