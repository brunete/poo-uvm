namespace A5_E3.EJ2;

internal class Program
{
    private static UtilidadesConsola _consola = new();
    
    static void Main(string[] args)
    {
        string q;
        do
        {
            var p = new Persona()
            {
                Nombre = _consola.SolicitarString("\nIngresa tu nombre: "),
                Edad = _consola.SolicitarEntero("\nIngresa tu edad: "),
                Sexo = _consola.SolicitarString("\nIngresa tu sexo (M/F): ", new[] { "M", "F" })
            };

            Console.WriteLine($"\nDatos de la persona\nNombre: {p.Nombre}\nEdad: {p.Edad}\nSexo: {p.Sexo.ToUpper()}\n");
            Console.WriteLine("Para salir presiona 'Enter'. Si quieres otro nombre escribe: SI");
            q = Console.ReadLine();
        } while (q == "SI");
    }
}