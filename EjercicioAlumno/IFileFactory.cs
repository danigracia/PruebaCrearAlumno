using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioAlumno
{
    public interface IFileFactory
    {
        string InsertarAlumnoTxt(CrearAlumno alumno, String path);
        string InsertarAlumnoJson(CrearAlumno alumno, String path);
    }
}
