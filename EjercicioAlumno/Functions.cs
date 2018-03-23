﻿using System;
using System.IO;
using System.Configuration;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EjercicioAlumno
{
    public class Functions
    {
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

        public static int TextMain()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("-----------------");
            Console.WriteLine("1-Crear nuevo alumno:");
            Console.WriteLine("2-Elegir en que formato serializar:");
            Console.WriteLine("3-Salir:");
            Console.WriteLine("Selecciona una opcion: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return option;
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
            Console.WriteLine("Introduce el ID:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce el nombre:");
            nombre = Console.ReadLine();
            Console.WriteLine("Introduce el apellido:");
            apellido = Console.ReadLine();
            Console.WriteLine("Introduce el DNI:");
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
            Console.WriteLine("Selecciona una opcion:");
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

        public static void Exit()
        {
            Console.WriteLine("Hasta pronto...");
            Thread.Sleep(1500);
        }
        public static bool CheckExit(int caseSwitch)
        {
            if (caseSwitch == 3)
            {
                return true;
            }
            return false;
        }
    }
}
