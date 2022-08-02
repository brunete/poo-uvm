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
    
    public string StringLineaTabla()
    {
        return
            $"{NumControlEscolar,10}|{Nombre,8}|{Apellido,10}|{Sexo,6}|{FechaNacimiento.ToString("dd/MM/yyyy"),12}|{Titulo,10}|{CedulaProfesional,13}";
    }

    public string StringBusqueda()
    {
        return $"{Nombre} {Apellido} ({Edad}) | Sexo: {Sexo} | Título: {Titulo} | Cédula prof: {CedulaProfesional}";
    }
}