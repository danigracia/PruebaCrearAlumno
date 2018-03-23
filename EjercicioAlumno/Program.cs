using System;
using System.IO;

namespace EjercicioAlumno
{
    class Program
    {
        static void Main(string[] args)
        {
            int caseSwitch = 0;
            int id;
            string nombre;
            string apellido;
            string dni;
            string path = @"alumnos.txt";
            while (true)
            {
                

                if (caseSwitch == 2)
                {
                    break;
                }


                Console.WriteLine("Menu:");
                Console.WriteLine("-----------------");
                Console.WriteLine("1-Crear nuevo alumno:");
                Console.WriteLine("2-Salir:");
                Console.WriteLine("Elige una opcion: ");
                caseSwitch = Convert.ToInt32(Console.ReadLine());

                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Has selecionado la opcion crear nuevo alumno:");
                        Console.WriteLine("Introduce el ID:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Introduce el nombre:");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Introduce el apellido:");
                        apellido = Console.ReadLine();
                        Console.WriteLine("Introduce el DNI:");
                        dni = Console.ReadLine();
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadLine();
                        if (!File.Exists(path))
                        {
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(id + "," + nombre + "," + apellido + "," + dni);
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine(id + "," + nombre + "," + apellido + "," + dni);
                            }
                        }                        
                        break;
                    case 2:
                        Console.WriteLine("Presiona cualquier tecla para salir...");
                        Console.ReadLine();
                        break;

                }
            }
        }
    }
}
