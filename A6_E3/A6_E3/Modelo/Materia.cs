namespace A6_E3.Modelo;

public class Materia
{
    public int ID { get; }

    public string Nombre { get; set; }

    public byte Creditos { get; set; }

    public Profesor Profesor { get; set; }

    public List<Calificacion> Calificaciones { get; }

    public Materia(int id, string nombre, byte creditos, Profesor profesor)
    {
        ID = id;
        Nombre = nombre;
        Creditos = creditos;
        Profesor = profesor;
        Calificaciones = new List<Calificacion>();
    }
    
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

    public bool EsValida()
    {
        if (ID <= 0)
        {
            return false;
        }

        if (string.IsNullOrEmpty(Nombre))
        {
            return false;
        }

        if (Creditos <= 0)
        {
            return false;
        }

        if (Profesor == null)
        {
            return false;
        }

        if (Calificaciones == null)
        {
            return false;
        }
        
        return true;
    }
}