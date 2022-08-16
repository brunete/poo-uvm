namespace A8_E3.Modelo;

public class Empleado : Persona
{
    public int IdOficina { get; set; }
    public string Usuario { get; set; }
    public float SueldoBruto { get; set; }

    public Empleado(int id, string nombre, string apellido, int idOficina, string usuario, float sueldoBruto)
        : base(id, nombre, apellido)
    {
        IdOficina = idOficina;
        Usuario = usuario;
        SueldoBruto = sueldoBruto;
    }
}