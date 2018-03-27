using System;
using System.IO;
using System.Configuration;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using static EjercicioAlumno.Enums;

namespace EjercicioAlumno
{
    public class Mains
    {
        
        public void MenuPrincipal()
        {
            FileFactory fileFac = new FileFactory();
            OptionsMainPrinc op = new OptionsMainPrinc();
            OptionsMainSec opSec = new OptionsMainSec();

            while (true)
            {
                string format = fileFac.GetFormat();
                int optionFormat = GetOption(format);
                string path = fileFac.GetPath(format);
                if (op == OptionsMainPrinc.Salir)
                {
                    break;
                }

                op = TextMainPrinc();

                switch (op)
                {
                    case OptionsMainPrinc.NuevoAlumno:
                        var newAlumno = TextMainSecAlum(optionFormat, path);
                        if (optionFormat == 1)
                        {
                            fileFac.InsertarAlumnoTxt(newAlumno, path);
                        }
                        else if (optionFormat == 2)
                        {
                            fileFac.InsertarAlumnoJson(newAlumno, path);
                        }
                        break;

                    case OptionsMainPrinc.CambiarFormato:
                        opSec = TextMainSec();
                        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        switch (opSec)
                        {
                            case OptionsMainSec.Txt:
                                config.AppSettings.Settings["format"].Value = "txt";
                                break;

                            case OptionsMainSec.Json:
                                config.AppSettings.Settings["format"].Value = "json";
                                break;
                        }

                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        break;

                    case OptionsMainPrinc.Salir:
                        op = Exit();
                        break;
                }
            }
        }

        public int GetOption(string format)
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

        public OptionsMainPrinc TextMainPrinc()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("-----------------");
            Console.WriteLine("1-Crear nuevo alumno:");
            Console.WriteLine("2-Elegir en que formato serializar:");
            Console.WriteLine("3-Salir:");
            Console.Write("Selecciona una opcion: ");
            var res = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return (OptionsMainPrinc)(res);
        }

        public OptionsMainSec TextMainSec()
        {
            Console.WriteLine("Has selecionado la opcion crear nuevo alumno:");
            Console.WriteLine("-----------------");
            Console.WriteLine("1- Txt:");
            Console.WriteLine("2- Json:");
            Console.Write("Selecciona una opcion: ");
            int res = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return (OptionsMainSec)(res);
        }

        public CrearAlumno TextMainSecAlum(int option, string path)
        {
            var guid = Guid.NewGuid().ToString();
            Console.WriteLine("Has selecionado la opcion crear nuevo alumno:");
            Console.WriteLine("-----------------");
            Console.Write("ID: ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduce el nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Introduce el apellido: ");
            var apellido = Console.ReadLine();
            Console.Write("Introduce el DNI: ");
            var dni = Console.ReadLine();

            Console.Clear();
            return new CrearAlumno(guid, id, nombre, apellido, dni);

        }

        public OptionsMainPrinc Exit()
        {
            Console.WriteLine("Hasta pronto...");
            Thread.Sleep(1500);
            return OptionsMainPrinc.Salir;
        }
    }
}

