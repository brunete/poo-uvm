using System.Xml.Serialization;
using A6_E3.Excepciones;
using A6_E3.Modelo;
using A6_E3.Utils;

namespace A6_E3;

internal class Program
{
    private static UtilidadesConsola _consola = new();
    private static Institucion _institucion = new();

    private static void Main(string[] args)
    {
        if (_consola.SolicitarBool("Cargar datos de prueba? (S/N): "))
            CargarDatosPrueba();

        int opcion;
        do
        {
            _consola.MostrarMenuPrincipal();
            opcion = _consola.SolicitarEntero("Elija una opción: ");
            EjecutarOpcionPrincipal(opcion);
        } while (opcion != 4);
    }

    #region -- CONSOLA --

    private static void CargarDatosPrueba()
    {
        /* ALUMNOS */
        var a1 = new Alumno()
        {
            Nombre = "Bruno",
            Apellido = "Yorda",
            FechaNacimiento = new DateTime(1990, 7, 7),
            Sexo = "M",
            Semestre = 5,
        };
        _institucion.NuevoAlumno(a1);

        var a2 = new Alumno()
        {
            Nombre = "Juan",
            Apellido = "Pérez",
            FechaNacimiento = new DateTime(1995, 10, 25),
            Sexo = "M",
            Semestre = 7,
        };
        _institucion.NuevoAlumno(a2);

        var a3 = new Alumno()
        {
            Nombre = "Maria",
            Apellido = "Hernández",
            FechaNacimiento = new DateTime(1984, 1, 16),
            Sexo = "F",
            Semestre = 2,
        };
        _institucion.NuevoAlumno(a3);

        /* PROFESORES */
        var p1 = new Profesor()
        {
            Nombre = "Peperino",
            Apellido = "Pomoro",
            FechaNacimiento = new DateTime(1972, 8, 15),
            Sexo = "M",
            Titulo = "Título 1",
            CedulaProfesional = "123456"
        };
        _institucion.NuevoProfesor(p1);

        var p2 = new Profesor()
        {
            Nombre = "Doña",
            Apellido = "Juanita",
            FechaNacimiento = new DateTime(1981, 9, 19),
            Sexo = "F",
            Titulo = "Título 2",
            CedulaProfesional = "987321"
        };
        _institucion.NuevoProfesor(p2);

        var p3 = new Profesor()
        {
            Nombre = "Juana",
            Apellido = "La Cubana",
            FechaNacimiento = new DateTime(1987, 7, 16),
            Sexo = "F",
            Titulo = "Título 3",
            CedulaProfesional = "654987"
        };
        _institucion.NuevoProfesor(p3);

        /* MATERIAS */
        var m1 = new Materia()
        {
            Nombre = "Materia 1",
            Creditos = 1,
            Profesor = p1,
        };
        _institucion.NuevaMateria(m1);

        var m2 = new Materia()
        {
            Nombre = "Materia 2",
            Creditos = 2,
            Profesor = p2,
        };
        _institucion.NuevaMateria(m2);

        var m3 = new Materia()
        {
            Nombre = "Materia 3",
            Creditos = 3,
            Profesor = p3,
        };
        _institucion.NuevaMateria(m3);
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
                } while (opcionSubmenu != 8);

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
                    EjecutarOpcionMaterias(opcionSubmenu);
                } while (opcionSubmenu != 6);

                break;
            case 4:
                Console.WriteLine("Programa finalizado...");
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
                BuscarAlumno();
                break;
            case 4:
                ModificarAlumno();
                break;
            case 5:
                EliminarAlumno();
                break;
            case 6:
                ConsultarMateriasDeAlumno();
                break;
            case 7:
                ModificarMateriasDeAlumno();
                break;
            case 8:
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
                NuevoProfesor();
                break;
            case 2:
                ConsultarProfesores();
                break;
            case 3:
                BuscarProfesor();
                break;
            case 4:
                ModificarProfesor();
                break;
            case 5:
                EliminarProfesor();
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
                NuevaMateria();
                break;
            case 2:
                MostrarMaterias(_institucion.Materias);
                break;
            case 3:
                BuscarMateria();
                break;
            case 4:
                ModificarMateria();
                break;
            case 5:
                EliminarMateria();
                break;
            case 6:
                break;
            default:
                Console.WriteLine("Opción inválida!");
                break;
        }
    }

    #endregion

    #region -- ALUMNOS --

    private static void NuevoAlumno()
    {
        _institucion.NuevoAlumno(new Alumno()
        {
            Nombre = _consola.SolicitarString("Nombre: "),
            Apellido = _consola.SolicitarString("Apellido: "),
            FechaNacimiento = _consola.SolicitarFecha("Fecha de nacimiento (dd/mm/aaaa): "),
            Sexo = _consola.SolicitarString("Sexo (M/F): ", null, new string[] { "M", "F" }).ToUpper()
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
                Console.WriteLine(alumno?.StringLineaTabla());
            }
        }
        else
        {
            Console.WriteLine("No hay alumnos registrados");
        }

        Console.WriteLine();
    }

    private static void BuscarAlumno()
    {
        var numControl = _consola.SolicitarEntero("Num control: ");
        var alumno = _institucion.BuscarAlumno(numControl);

        Console.WriteLine(alumno != null ? alumno.StringBusqueda() : "Alumno no encontrado");
        Console.WriteLine();
    }

    private static void ModificarAlumno()
    {
        ConsultarAlumnos();
        if (_institucion.Alumnos.Any())
        {
            try
            {
                _institucion.ModificarAlumno(new Alumno()
                {
                    NumControlEscolar = _consola.SolicitarEntero("Num. control: "),
                    Nombre = _consola.SolicitarString("Nombre: "),
                    Apellido = _consola.SolicitarString("Apellido: "),
                    FechaNacimiento = _consola.SolicitarFecha("Fecha de nacimiento (dd/mm/aaaa): "),
                    Sexo = _consola.SolicitarString("Sexo (M/F): ", null, new string[] { "M", "F" }).ToUpper(),
                    Semestre = _consola.SolicitarEntero("Semestre: ")
                });
            }
            catch (IdInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEncontradoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void EliminarAlumno()
    {
        ConsultarAlumnos();
        if (_institucion.Alumnos.Any())
        {
            try
            {
                int numControl = _consola.SolicitarEntero("Num. control: ");
                _institucion.EliminarAlumno(numControl);
            }
            catch (IdInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEncontradoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void ConsultarMateriasDeAlumno()
    {
        Console.WriteLine("Alumnos disponibles:");
        ConsultarAlumnos();
        if (_institucion.Alumnos.Any())
        {
            try
            {
                var idAlumno =
                    _consola.SolicitarEntero("Ingrese el número de control escolar del alumno a consultar: ");

                var a = _institucion.Alumnos.First(x => x.NumControlEscolar == idAlumno);

                if (a == null)
                {
                    Console.WriteLine("Alumno inválido!");
                    return;
                }
                
                Console.WriteLine($"Materias asignadas a {a.Nombre} {a.Apellido}");
                MostrarMaterias(a.Materias);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    private static void ModificarMateriasDeAlumno()
    {
        Console.WriteLine("Alumnos disponibles:");
        ConsultarAlumnos();
        if (_institucion.Alumnos.Any())
        {
            try
            {
                var idAlumno = _consola.SolicitarEntero("Ingrese el número de control escolar del alumno a modificar: ");
                var a = _institucion.Alumnos.First(x => x.NumControlEscolar == idAlumno);

                if (a == null)
                {
                    Console.WriteLine("Alumno inválido!");
                    return;
                }

                Console.WriteLine($"Materias asignadas a {a.Nombre} {a.Apellido}");
                MostrarMaterias(a.Materias);

                int opcion;
                do
                {
                    _consola.MostrarMenuMateriasDeAlumno();
                    opcion = _consola.SolicitarEntero("¿Qué desea hacer?: ");

                    int idMateria;
                    Materia? materia;

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Materias disponibles: ");
                            MostrarMaterias(_institucion.Materias.Except(a.Materias).ToList());

                            idMateria = _consola.SolicitarEntero("Ingrese el ID de la materia a asignar: ");
                            materia = _institucion.BuscarMateria(idMateria);

                            if (materia != null)
                            {
                                try
                                {
                                    a.AgregarMateria(materia);
                                    Console.WriteLine("Materia agregada!\n");
                                }
                                catch (MateriaInvalidaException)
                                {
                                    Console.WriteLine("Materia inválida!\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID inválido!");
                            }

                            break;
                        case 2:
                            Console.WriteLine($"Materias asignadas a {a.Nombre} {a.Apellido}");
                            MostrarMaterias(a.Materias);
                            
                            idMateria = _consola.SolicitarEntero("Ingrese el ID de la materia a eliminar: ");
                            materia = _institucion.BuscarMateria(idMateria);

                            if (materia != null)
                            {
                                try
                                {
                                    a.EliminarMateria(materia);
                                    Console.WriteLine("Materia eliminada!\n");
                                }
                                catch (MateriaInvalidaException)
                                {
                                    Console.WriteLine("Materia inválida!\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID inválido!\n");
                            }

                            break;
                        default:
                            Console.WriteLine("Opción incorrecta!");
                            break;
                    }
                } while (opcion != 3);
            }
            catch (IdInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEncontradoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    #endregion

    #region -- PROFESORES --

    private static void NuevoProfesor()
    {
        _institucion.NuevoProfesor(new Profesor()
        {
            Nombre = _consola.SolicitarString("Nombre: "),
            Apellido = _consola.SolicitarString("Apellido: "),
            FechaNacimiento = _consola.SolicitarFecha("Fecha de nacimiento (dd/mm/aaaa): "),
            Sexo = _consola.SolicitarString("Sexo (M/F): ", null, new string[] { "M", "F" }).ToUpper(),
            Titulo = _consola.SolicitarString("Título: "),
            CedulaProfesional = _consola.SolicitarString("Cédula prof.: ")
        });
    }

    private static void ConsultarProfesores()
    {
        if (_institucion.Profesores.Any())
        {
            var encabezado =
                $"{"Num. Ctrl.",10}|{" Nombre ",8}|{" Apellido ",10}|{" Sexo ",6}|{" Fecha nac. ",12}|{" Titulo ",10}|{" Cedula prof. ",13}";
            Console.WriteLine(encabezado);

            foreach (var profesor in _institucion.Profesores)
            {
                Console.WriteLine(profesor.StringLineaTabla());
            }
        }
        else
        {
            Console.WriteLine("No hay profesores registrados");
        }

        Console.WriteLine();
    }

    private static void BuscarProfesor()
    {
        var numControl = _consola.SolicitarEntero("Num control: ");
        var profesor = _institucion.BuscarProfesor(numControl);

        Console.WriteLine(profesor != null ? profesor.StringBusqueda() : "Profesor no encontrado");
        Console.WriteLine();
    }

    private static void ModificarProfesor()
    {
        ConsultarProfesores();
        if (_institucion.Profesores.Any())
        {
            try
            {
                _institucion.ModificarProfesor(new Profesor()
                {
                    NumControlEscolar = _consola.SolicitarEntero("Num. control: "),
                    Nombre = _consola.SolicitarString("Nombre: "),
                    Apellido = _consola.SolicitarString("Apellido: "),
                    FechaNacimiento = _consola.SolicitarFecha("Fecha de nacimiento (dd/mm/aaaa): "),
                    Sexo = _consola.SolicitarString("Sexo (M/F): ", null, new string[] { "M", "F" }).ToUpper(),
                    Titulo = _consola.SolicitarString("Título: "),
                    CedulaProfesional = _consola.SolicitarString("Cédula prof.: "),
                });
            }
            catch (IdInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEncontradoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void EliminarProfesor()
    {
        ConsultarProfesores();
        if (_institucion.Profesores.Any())
        {
            try
            {
                int numControl = _consola.SolicitarEntero("Num. control: ");
                _institucion.EliminarProfesor(numControl);
            }
            catch (IdInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEncontradoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    #endregion

    #region -- MATERIAS --

    private static void NuevaMateria()
    {
        var materia = new Materia()
        {
            Nombre = _consola.SolicitarString("Nombre: "),
            Creditos = _consola.SolicitarEntero("Créditos: "),
        };

        Profesor? prof;
        do
        {
            int numControl = _consola.SolicitarEntero("Núm. control del profesor: ");
            prof = _institucion.BuscarProfesor(numControl);
            if (prof == null)
                Console.WriteLine("Profesor no encontrado!");
        } while (prof == null);

        materia.Profesor = prof;

        _institucion.NuevaMateria(materia);
    }

    private static void MostrarMaterias(List<Materia?> materias)
    {
        if (_institucion.Materias.Any())
        {
            var encabezado =
                $"{" ID ",4}|{" Nombre ",10}|{" Créditos ",10}|{" Profesor ",10}";
            Console.WriteLine(encabezado);

            foreach (var materia in materias)
            {
                Console.WriteLine(materia.StringLineaTabla());
            }
        }
        else
        {
            Console.WriteLine("No hay materias registradas");
        }

        Console.WriteLine();
    }

    private static void BuscarMateria()
    {
        var id = _consola.SolicitarEntero("ID: ");
        var materia = _institucion.BuscarMateria(id);

        Console.WriteLine(materia != null ? materia.StringBusqueda() : "Materia no encontrada");
        Console.WriteLine();
    }

    private static void ModificarMateria()
    {
        MostrarMaterias(_institucion.Materias);
        if (_institucion.Materias.Any())
        {
            try
            {
                var materia = new Materia()
                {
                    Nombre = _consola.SolicitarString("Nombre: "),
                    Creditos = _consola.SolicitarEntero("Créditos: "),
                };

                Profesor? prof;
                do
                {
                    int numControl = _consola.SolicitarEntero("Núm. control del profesor: ");
                    prof = _institucion.BuscarProfesor(numControl);
                    if (prof == null)
                        Console.WriteLine("Profesor no encontrado!");
                } while (prof == null);

                materia.Profesor = prof;

                _institucion.ModificarMateria(materia);
            }
            catch (IdInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEncontradoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void EliminarMateria()
    {
        MostrarMaterias(_institucion.Materias);
        if (_institucion.Materias.Any())
        {
            try
            {
                int id = _consola.SolicitarEntero("ID: ");
                _institucion.EliminarMateria(id);
            }
            catch (IdInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoEncontradoException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    #endregion
}