namespace A5_E3.Ejercicio2;

public class Persona
{
    public static readonly string[] ValoresAceptadosSexo = new[] { "M", "F" };
    public string Nombre { get; set; }
    
    public int Edad { get; set; }
    
    public string Sexo { get; set; }

    public override string ToString()
    {
        return $"{Nombre} | {Edad} | {Sexo}";
    }
}