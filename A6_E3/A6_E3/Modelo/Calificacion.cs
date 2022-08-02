namespace A6_E3.Modelo;

public class Calificacion
{
    public int ID { get; }

    public Alumno Alumno { get; set; }

    public Profesor Profesor { get; set; }

    public byte Nota { get; set; }

    public Calificacion(int id, Alumno alumno, Profesor profesor, byte nota)
    {
        ID = id;
        Alumno = alumno;
        Profesor = profesor;
        Nota = nota;
    }

    public void ActualizarCalificacion(Calificacion calificacion)
    {
        throw new NotImplementedException();
    }

    public bool EsValida()
    {
        if (ID <= 0)
        {
            return false;
        }

        if (Alumno == null)
        {
            return false;
        }

        if (Profesor == null)
        {
            return false;
        }

        if (Nota < 0)
        {
            return false;
        }

        return true;
    }
}