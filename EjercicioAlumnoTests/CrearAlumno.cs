using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;
using System.Collections.Generic;

namespace EjercicioAlumno.Tests
{
    public class CrearAlumno
    {
        private int id;
        private string nombre;
        private string apellido;
        private string dni;


        public CrearAlumno()
        {

        }

        public CrearAlumno(int id, string nombre, string apellido, string dni)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is CrearAlumno alumno &&
                   id == alumno.id &&
                   nombre == alumno.nombre &&
                   apellido == alumno.apellido &&
                   dni == alumno.dni;
        }

        public override int GetHashCode()
        {
            var hashCode = 1619805141;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellido);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(dni);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
