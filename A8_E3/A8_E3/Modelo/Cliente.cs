namespace A8_E3.Modelo;

public class Cliente : Persona
{
    public string TelefonoContacto { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Cliente(int id, string nombre, string apellido, string telefono, string email, string direccion)
        : base(id, nombre, apellido)
    {
        TelefonoContacto = telefono;
        Email = email;
        Direccion = direccion;
    }
}