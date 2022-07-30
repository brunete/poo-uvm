namespace A4_E3.Modelo;

public class Materia
{
    public int ID { get; set; }

    public string Nombre { get; set; }

    public byte Creditos { get; set; }

    public Profesor Profesor { get; set; }

    public List<Calificacion> Calificaciones { get; set; }

    public void ActualizarDatos(Materia materia)
    {
        throw new NotImplementedException();
    }

    public void Calificar(Alumno alumno, Profesor profesor)
    {
        throw new NotImplementedException();
    }

    public void ActualizarCalificacion(Calificacion calificacion)
    {
        throw new NotImplementedException();
    }
}