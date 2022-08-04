namespace A5_E3.EJ1;

public class Program
{
    private static UtilidadesConsola _consola = new();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n\nSelecciona la figura: \n");
            Console.WriteLine("1.- Cuadrado/Rectángulo.");
            Console.WriteLine("2.- Triángulo.");
            Console.WriteLine("3.- Circunferencia.");
            Console.WriteLine("4.- Trapecio");
            Console.WriteLine("0.- Salir.");

            opcion = _consola.SolicitarInt("Elija una opción: ");

            if (opcion is < 0 or > 4)
                Console.WriteLine("¡ Solo puedes introducir los valores idicados !");

            double base1;
            double altura;

            switch (opcion)
            {
                case 1:
                    base1 = _consola.SolicitarDouble("\nIntroduce el valor de la base: ");
                    altura = _consola.SolicitarDouble("Introduce el valor de la altura: ");

                    Console.WriteLine($"\nEl área del cuadrado/rectángulo es: {Area(base1, altura)}");
                    break;

                case 2:
                    base1 = _consola.SolicitarDouble("\nIntroduce el valor de la base: ");
                    altura = _consola.SolicitarDouble("Introduce el valor de la altura: ");

                    Console.WriteLine("\nEl área del triángulo es: " + Area(base1, altura, 2));
                    break;

                case 3:
                    double radio = _consola.SolicitarDouble("\nIntroduce el valor del radio: ");

                    Console.WriteLine($"\nEl área de la circunferencia es: {Math.Round(Area(radio), 2)}");
                    break;

                case 4:
                    base1 = _consola.SolicitarDouble("\nIntroduce el valor de la base: ");
                    var base2 = _consola.SolicitarDouble("\nIntroduce el valor de la base: ");
                    altura = _consola.SolicitarDouble("Introduce el valor de la altura: ");

                    Console.WriteLine("\nEl área del trapecio es: " + Area(base1, base2, altura));
                    break;
            }
        } while (opcion != 0);

        Console.WriteLine("....¡¡¡ A D I O S !!!....");
    }

    static double Area(double lado1, double lado2) => lado1 * lado2;

    static double Area(double @base, double altura, int dos) => @base * altura / dos;
    
    static double Area(double radio) => Math.PI * radio * radio;
    
    static double Area(double base1, double base2, double altura) => (altura * ((base1 + base2) / 2));
}