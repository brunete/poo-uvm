using A6_E3.Excepciones;
using A6_E3.Modelo;

namespace A6_E3;

public class Institucion
{
    private int _numControlEscolar = 1;
    private int _idMateria = 1;
    private int _idCalificacion = 1;
    
    public List<Alumno?> Alumnos { get; }

    public List<Profesor> Profesores { get; }

    public List<Materia> Materias { get; }

    public Institucion()
    {
        Alumnos = new List<Alumno?>();
        Profesores = new List<Profesor>();
        Materias = new List<Materia>();
    }

    /* ALUMNOS */
    public void NuevoAlumno(Alumno alumno)
    {
        if (!alumno.EsValido())
            throw new ProfesorInvalidoException();

        alumno.NumControlEscolar = _numControlEscolar;
        _numControlEscolar++;

        Alumnos.Add(alumno);
    }

    public Alumno? BuscarAlumno(int numControlEscolar)
    {
        return Alumnos.Find(a => a.NumControlEscolar == numControlEscolar);
    }

    public void ActualizarAlumno(Alumno alumno)
    {
        if (!alumno.EsValido())
            throw new AlumnoInvalidoException();

        var alumnoViejo = BuscarAlumno(alumno.NumControlEscolar);
        alumnoViejo?.ActualizarDatos(alumno);
    }

    public void EliminarAlumno(int numControlEscolar)
    {
        if (numControlEscolar <= 0) throw new IdInvalidoException();

        var alumno = BuscarAlumno(numControlEscolar);
        if (alumno != null) Alumnos.Remove(alumno);
    }

    /* PROFESORES */

    public void NuevoProfesor(Profesor profesor)
    {
        if (!profesor.EsValido())
            throw new ProfesorInvalidoException();

        profesor.NumControlEscolar = _numControlEscolar;
        _numControlEscolar++;
        
        Profesores.Add(profesor);
    }

    public Profesor? BuscarProfesor(int numControlEscolar)
    {
        return Profesores.Find(p => p.NumControlEscolar == numControlEscolar);
    }

    public void ActualizarProfesor(Profesor profesor)
    {
        if (!profesor.EsValido())
            throw new ProfesorInvalidoException();

        var profesorViejo = BuscarProfesor(profesor.NumControlEscolar);
        profesorViejo?.ActualizarDatos(profesor);
    }

    public void EliminarProfesor(int numControlEscolar)
    {
        if (numControlEscolar <= 0) throw new IdInvalidoException();

        var profesor = BuscarProfesor(numControlEscolar);
        if (profesor != null) Profesores.Remove(profesor);
    }

    /* MATERIAS */

    public void NuevaMateria(Materia materia)
    {
        if (!materia.EsValida())
            throw new MateriaInvalidaException();

        materia.ID = _idMateria;
        _idMateria++;
        
        Materias.Add(materia);
    }

    public Materia? BuscarMateria(int id)
    {
        return Materias.Find(m => m.ID == id);
    }

    public void ActualizarMateria(Materia materia)
    {
        if (!materia.EsValida())
            throw new AlumnoInvalidoException();

        var materiaVieja = BuscarMateria(materia.ID);
        materiaVieja?.ActualizarDatos(materia);
    }

    public void EliminarMateria(int id)
    {
        if (id <= 0) throw new IdInvalidoException();

        var materia = BuscarMateria(id);
        if (materia != null) Materias.Remove(materia);
    }

    /* OTRAS OPERACIONES */
    
    public void Calificar(Materia materia, Calificacion calificacion)
    {
        if (!materia.EsValida())
            throw new MateriaInvalidaException();

        if (!calificacion.EsValida())
            throw new CalificacionInvalidaException();
    }
}