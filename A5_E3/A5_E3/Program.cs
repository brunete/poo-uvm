namespace A5_E3.Ejercicio2;

public class Program
{
    private static UtilidadesConsola _consola = new UtilidadesConsola();
    
    public static void Main(string[] args)
    {
        Persona p = SolicitarDatosPersona();
        Imprimir(p);
        Console.ReadLine();
    }

    private static void Imprimir(Persona p)
    {
        Console.WriteLine(p.ToString());
    }

    private static Persona SolicitarDatosPersona()
    {
        var p = new Persona()
        {
            Nombre = _consola.SolicitarString("Nombre: "),
            Edad = _consola.SolicitarEntero("Edad: "),
            Sexo = _consola.SolicitarString("Sexo M/F: ", null, Persona.ValoresAceptadosSexo).ToUpper()
        };
        
        return p;
    }
}
