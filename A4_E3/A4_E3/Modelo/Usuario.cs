namespace A4_E3.Modelo;

public class Usuario
{
    public int NumControlEscolar { get; set; }

    public string Nombre { get; set; }
    
    public string Apellido { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public Sexo Sexo { get; set; }

    public void ActualizarDatos(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}