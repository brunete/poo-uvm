namespace A3_BBYH;

public class Cliente
{
    public int NumeroCliente { get; set; }
    
    public string? Nombre { get; set; }
    
    public string? Apellido { get; set; }
    
    public DateTime FechaNacimiento { get; set; }
    
    public string? Email { get; set; }

    public bool Activo { get; set; }

    /// <summary>
    /// Actualiza los datos personales del cliente.
    /// </summary>
    /// <param name="c">Objeto Cliente con datos nuevos.</param>
    public void ActualizarDatos(Cliente c)
    {
        
    }

    /// <summary>
    /// Setea el usuario como inactivo en el sistema.
    /// </summary>
    public void Desactivar()
    {
        
    }

    public override string ToString()
    {
        return $"{NumeroCliente,5}|{Nombre,10}|{Apellido,10}|{FechaNacimiento.ToShortDateString(),12}|{Email,10}";
    }
}