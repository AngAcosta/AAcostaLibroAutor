using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaLibroAutorEntities context = new DL.AAcostaLibroAutorEntities())
                {
                    var query = context.AutorGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = obj.IdAutor;
                            autor.NombreAutor = obj.NombreAutor;
                            autor.ApellidoPaterno = obj.ApellidoPaterno;
                            autor.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(autor);
                        }
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
    }
}