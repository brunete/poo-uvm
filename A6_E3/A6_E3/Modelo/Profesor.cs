using A6_E3.Excepciones;

namespace A6_E3.Modelo;

public class Profesor : Usuario
{
    public string Titulo { get; set; }

    public string CedulaProfesional { get; set; }

    public void ModificarDatos(Profesor profesor)
    {
        if (profesor.EsValido())
        {
            base.ModificarDatos(profesor);

            Titulo = profesor.Titulo;
            CedulaProfesional = profesor.CedulaProfesional;
        }
        else
        {
            throw new ProfesorInvalidoException();
        }
    }

    public new bool EsValido()
    {
        if (base.EsValido())
        {
            if (string.IsNullOrEmpty(Titulo))
            {
                return false;
            }

            if (string.IsNullOrEmpty(CedulaProfesional))
            {
                return false;
            }

            return true;
        }

        return false;
    }
}