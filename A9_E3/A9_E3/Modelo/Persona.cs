namespace A6_E3.Modelo;

public class Persona
{
    public int NumControlEscolar { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public int Edad => DateTime.Now.Subtract(FechaNacimiento).Days / 365;

    public string Sexo { get; set; }

    public void ModificarDatos(Persona persona)
    {
        Nombre = string.IsNullOrEmpty(persona.Nombre) ? Nombre : persona.Nombre;
        Apellido = string.IsNullOrEmpty(persona.Apellido) ? Apellido : persona.Apellido;
        FechaNacimiento = persona.FechaNacimiento;
        Sexo = string.IsNullOrEmpty(persona.Sexo) ? Sexo : persona.Sexo;
    }

    public bool EsValido()
    {
        if (string.IsNullOrEmpty(Nombre))
        {
            return false;
        }

        if (string.IsNullOrEmpty(Apellido))
        {
            return false;
        }

        if (string.IsNullOrEmpty(Sexo))
        {
            return false;
        }

        if (FechaNacimiento > DateTime.Now)
        {
            return false;
        }

        return true;
    }
}