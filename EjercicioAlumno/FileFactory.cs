using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioAlumno
{
    public class FileFactory 
    {
        public string GetPath(string format)
        {
            return @"alumnos." + format;
        }

        public string GetFormat()
        {
            string format = new AppSettingsReader().GetValue("format", typeof(System.String)).ToString();
            return format;
        }

        public void InsertarAlumnoTxt(CrearAlumno alumno, String path)
        {
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(alumno.Id + "," + alumno.Nombre + "," + alumno.Apellido + "," + alumno.Dni);
            sw.Close();
        }

        public void InsertarAlumnoJson(CrearAlumno alumno, String path)
        {
            if (!File.Exists(path))
            {
                var fileJson = File.Create(path);
                fileJson.Close();
            }
            var initialJson = File.ReadAllText(path);
            string json;

            var list = JsonConvert.DeserializeObject<List<CrearAlumno>>(initialJson);
            if (list == null)
            {
                list = new List<CrearAlumno>();
            }
            list.Add(alumno);

            json = JsonConvert.SerializeObject(list, Formatting.Indented);

            System.IO.File.WriteAllText(path, json);
        }
    }
}
