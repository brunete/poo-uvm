namespace A6_E3.Modelo;

public class Usuario
{
    public int NumControlEscolar { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public int Edad => DateTime.Now.Subtract(FechaNacimiento).Days / 365;

    public string Sexo { get; set; }

    public Usuario()
    {
    }

    public void ActualizarDatos(Usuario usuario)
    {
        throw new NotImplementedException();
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