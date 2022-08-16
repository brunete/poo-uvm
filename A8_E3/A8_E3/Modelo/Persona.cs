namespace A8_E3.Modelo;

public class Persona
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public Persona(int id, string nombre, string apellido)
    {
        ID = id;
        Nombre = nombre;
        Apellido = apellido;
    }
}