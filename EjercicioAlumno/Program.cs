using System;
using System.IO;

namespace EjercicioAlumno
{
    class Program : Functions
    {
        static void Main(string[] args)
        {
            int caseSwitch = 0;

            while (true)
            {

                string format = GetFormat();
                int option = GetOption(format);
                string path = GetPath(format);

                if (CheckExit(caseSwitch) == true)
                {
                    break;
                }

                caseSwitch = TextMain();

                switch (caseSwitch)
                {
                    case 1:
                        NewAlumno(option, path);
                        break;

                    case 2:
                        SelectFileSave();
                        break;

                    case 3:
                        Exit();
                        break;

                }
            }
        }
    }
}

