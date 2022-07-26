﻿namespace A6_E3.Modelo;

public class Materia
{
    public int ID { get; set; }

    public string Nombre { get; set; }

    public int Creditos { get; set; }

    public Profesor Profesor { get; set; }

    public List<Calificacion> Calificaciones { get; }

    public Materia()
    {
        Calificaciones = new List<Calificacion>();
    }
    
    public void ModificarDatos(Materia materia)
    {
        throw new NotImplementedException();
    }

    public void Calificar(Alumno alumno, Profesor profesor)
    {
        throw new NotImplementedException();
    }

    public void ModificarCalificacion(Calificacion calificacion)
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

    public string StringLineaTabla()
    {
        return $"{ID,4}|{Nombre,10}|{Creditos,10}|{Profesor.Nombre + " " + Profesor.Apellido,10}";
    }

    public string StringBusqueda()
    {
        return $"[{ID}] {Nombre} ({Creditos}) | Profesor: {Profesor.Nombre} {Profesor.Apellido}";
    }
}