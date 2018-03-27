using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioAlumno
{
    public interface IFileFactory
    {
        void InsertarAlumnoTxt(CrearAlumno alumno, String path);
        void InsertarAlumnoJson(CrearAlumno alumno, String path);
    }
}
