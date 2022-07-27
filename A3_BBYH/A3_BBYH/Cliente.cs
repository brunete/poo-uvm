namespace A3_BBYH;

public class Cliente
{
    public int NumeroCliente { get; set; }
    
    public string? Nombre { get; set; }
    
    public string? Apellido { get; set; }
    
    public DateTime FechaNacimiento { get; set; }
    
    public string? Email { get; set; }

    public void ActualizarDatos(Cliente c)
    {
        
    }

    public void ActivarNotificacionesEmail()
    {
        
    }

    public override string ToString()
    {
        return $"{NumeroCliente,5}|{Nombre,10}|{Apellido,10}|{FechaNacimiento.ToShortDateString(),12}|{Email,10}";
    }
}