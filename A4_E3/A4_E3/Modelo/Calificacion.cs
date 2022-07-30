namespace A4_E3.Modelo;

public class Calificacion
{
    public int ID { get; set; }
    
    public Alumno Alumno { get; set; }

    public Profesor Profesor { get; set; }

    public byte Nota { get; set; }

    public void ActualizarCalificacion(Calificacion calificacion)
    {
        throw new NotImplementedException();
    }
}