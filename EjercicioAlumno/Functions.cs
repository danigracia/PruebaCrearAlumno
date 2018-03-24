using System;
using System.IO;
using System.Configuration;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EjercicioAlumno
{
    public class Functions
    {
        public enum Options
        {
            NuevoAlumno = 1,
            CambiarFormato = 2,
            Salir = 3
            
        }

        public static void MenuPrincipal()
        {

            Options caseSwitch = Options.NuevoAlumno;

            while (true)
            {               

                caseSwitch = Switch(caseSwitch);

                if (caseSwitch == Options.Salir)
                {
                    break;
                }

            }
        }
        public static Options Switch(Options caseSwitch)
        {

            string format = GetFormat();
            int option = GetOption(format);
            string path = GetPath(format);

            

            caseSwitch = TextMain();

            switch (caseSwitch)
            {
                case Options.NuevoAlumno:
                    NewAlumno(option, path);
                    return Options.NuevoAlumno;

                case Options.CambiarFormato:
                    SelectFileSave();
                    return Options.CambiarFormato;

                case Options.Salir:
                    caseSwitch = Exit();
                    return Options.Salir;

                

            }
            return Options.Salir;
        }

        public static int GetOption(string format)
        {
            int option = 0;
            if (format == "txt")
            {
                option = 1;
            }
            else if (format == "json")
            {
                option = 2;
            }
            return option;
        }

        public static string GetFormat()
        {
            string format = new AppSettingsReader().GetValue("format", typeof(System.String)).ToString();
            return format;
        }

        public static Options TextMain()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("-----------------");
            Console.WriteLine("1-Crear nuevo alumno:");
            Console.WriteLine("2-Elegir en que formato serializar:");
            Console.WriteLine("3-Salir:");
            Console.Write("Selecciona una opcion: ");
            int sel = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            if (sel == 1)
            {
                return Options.NuevoAlumno;
            }
            else if (sel == 2)
            {
                return Options.CambiarFormato;
            }
            else if (sel == 3)
            {
                return Options.Salir;
            }
            else return Options.Salir;

            
        }

        public static void NewAlumno(int option, string path)
        {
            int id;
            string nombre;
            string apellido;
            string dni;
            string json;
            Console.WriteLine("Has selecionado la opcion crear nuevo alumno:");
            Console.WriteLine("-----------------");
            Console.Write("Introduce el ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduce el nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Introduce el apellido: ");
            apellido = Console.ReadLine();
            Console.Write("Introduce el DNI: ");
            dni = Console.ReadLine();

            if (option == 1)
            {
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
            }
            else if (option == 2)
            {
                var initialJson = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<CrearAlumno>>(initialJson);
                list.Add(new CrearAlumno()
                {
                    Id = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni
                });

                json = JsonConvert.SerializeObject(list, Formatting.Indented);

                System.IO.File.WriteAllText(path, json);
                

            }
            Console.Clear();

        }

        public static void SelectFileSave()
        {
            Console.WriteLine("Has selecionado la opcion crear nuevo alumno:");
            Console.WriteLine("-----------------");
            Console.WriteLine("1- Txt:");
            Console.WriteLine("2- Json:");
            Console.Write("Selecciona una opcion: ");
            int option = Convert.ToInt32(Console.ReadLine());
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (option == 1)
            {
                config.AppSettings.Settings["format"].Value = "txt";
            }
            else if (option == 2)
            {
                config.AppSettings.Settings["format"].Value = "json";
            }
            
            config.Save(ConfigurationSaveMode.Modified);
            Console.Clear();
        }

        public static string GetPath(string format)
        {
            return @"alumnos." + format;
        }

        public static Options Exit()
        {
            Console.WriteLine("Hasta pronto...");
            Thread.Sleep(1500);
            return Options.Salir;
        }
       
    }
}

