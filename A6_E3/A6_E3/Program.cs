using A6_E3.Modelo;
using A6_E3.Utils;

namespace A6_E3;

internal class Program
{
    private static UtilidadesConsola _consola = new();
    private static Institucion _institucion = new();

    private static void Main(string[] args)
    {
        int opcion;
        do
        {
            _consola.MostrarMenuPrincipal();
            opcion = _consola.SolicitarEntero("Elija una opción: ");
            EjecutarOpcionPrincipal(opcion);
        } while (opcion != 4);
    }

    private static void EjecutarOpcionPrincipal(int opcion)
    {
        int opcionSubmenu;
        switch (opcion)
        {
            case 1:
                do
                {
                    _consola.MostrarMenuAlumnos();
                    opcionSubmenu = _consola.SolicitarEntero("Elija una opción: ");
                    EjecutarOpcionAlumnos(opcionSubmenu);
                } while (opcionSubmenu != 7);

                break;
            case 2:
                do
                {
                    _consola.MostrarMenuProfesores();
                    opcionSubmenu = _consola.SolicitarEntero("Elija una opción: ");
                    EjecutarOpcionProfesores(opcionSubmenu);
                } while (opcionSubmenu != 6);

                break;
            case 3:
                do
                {
                    _consola.MostrarMenuMaterias();
                    opcionSubmenu = _consola.SolicitarEntero("Elija una opción: ");
                    EjecutarOpcionProfesores(opcionSubmenu);
                } while (opcionSubmenu != 6);

                break;
            case 4:
                Console.WriteLine("Programa finalizado!");
                break;
            default:
                Console.WriteLine("Opción inválida!");
                break;
        }
    }

    private static void EjecutarOpcionAlumnos(int opcion)
    {
        switch (opcion)
        {
            case 1:
                NuevoAlumno();
                break;
            case 2:
                ConsultarAlumnos();
                break;
            case 3:
                // ConsultarMateriasDeAlumno();
                break;
            case 4:
                // BuscarAlumno();
                break;
            case 5:
                // ModificarAlumno();
                break;
            case 6:
                // EliminarAlumno();
                break;
            case 7:
                break;
            default:
                Console.WriteLine("Opción inválida!");
                break;
        }
    }

    private static void EjecutarOpcionProfesores(int opcion)
    {
        switch (opcion)
        {
            case 1:
                // NuevoProfesor();
                break;
            case 2:
                // ConsultarProfesores();
                break;
            case 3:
                // BuscarProfesor();
                break;
            case 4:
                // ModificarProfesor();
                break;
            case 5:
                // EliminarProfesor();
                break;
            case 6:
                break;
            default:
                Console.WriteLine("Opción inválida!");
                break;
        }
    }

    private static void EjecutarOpcionMaterias(int opcion)
    {
        switch (opcion)
        {
            case 1:
                // NuevaMateria();
                break;
            case 2:
                // ConsultarMateria();
                break;
            case 3:
                // BuscarMateria();
                break;
            case 4:
                // ModificarMateria();
                break;
            case 5:
                // EliminarMateria();
                break;
            case 6:
                break;
            default:
                Console.WriteLine("Opción inválida!");
                break;
        }
    }

    private static void NuevoAlumno()
    {
        _institucion.NuevoAlumno(new Alumno()
        {
            Nombre = _consola.SolicitarString("Nombre: "),
            Apellido = _consola.SolicitarString("Apellido: "),
            FechaNacimiento = _consola.SolicitarFecha("Fecha de nacimiento: "),
            Sexo = _consola.SolicitarString("Sexo: ", null, new string[] { "M", "F" }).ToUpper()
        });
    }

    private static void ConsultarAlumnos()
    {
        if (_institucion.Alumnos.Any())
        {
            var encabezado =
                $"{"Num. Ctrl.",10}|{" Nombre ",8}|{" Apellido ",10}|{" Sexo ",6}|{" Fecha nac. ",12}|{" Semestre ",5}";
            Console.WriteLine(encabezado);

            foreach (var alumno in _institucion.Alumnos)
            {
                Console.WriteLine(alumno.ToString());
            }
        }
        else
        {
            Console.WriteLine("No hay alumnos");
        }

        Console.WriteLine();
    }
}