using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioAlumno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace EjercicioAlumno.Tests
{
    [TestClass()]
    public class EjercicioAlumnoIntegrationTests
    {
        FileFactory iFileFactory = new FileFactory();

        [DataRow(1, "dani", "gracia", "1234", @"alumnos.json")]
        [DataTestMethod]
        public void InsertarAlumnoJson(int id, string nombre, string apellido, string dni, string path)
        {
            CrearAlumno alumno = new CrearAlumno(id, nombre, apellido, dni);

            iFileFactory.InsertarAlumnoJson(alumno, path);
            var allJson = iFileFactory.GetDataFileJson(path);
            bool found = false;
            var list = JsonConvert.DeserializeObject<List<CrearAlumno>>(allJson);
            foreach (var al in list)
            {
                if (alumno.Equals(al))
                {
                    found = true;
                    break;
                }
            }
            Assert.IsTrue(found);
        }
        [DataRow(1, "dani", "gracia", "1234", @"alumnos.txt")]
        [DataTestMethod]
        public void InsertarAlumnoTxt(int id, string nombre, string apellido, string dni, string path)
        {
            CrearAlumno alumno = new CrearAlumno(id, nombre, apellido, dni);
            iFileFactory.InsertarAlumnoTxt(alumno, path);
            string al = id + "," + nombre + "," + apellido + "," + dni;
            int countLines = File.ReadAllLines(path).Length;
            var lastLine = File.ReadLines(path).Skip(countLines - 1).Take(1).First();
            Assert.IsTrue(al.Equals(lastLine));

        }
    }
}
