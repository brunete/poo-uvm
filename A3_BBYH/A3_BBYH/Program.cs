namespace A3_BBYH;

internal class Program
{
    private static readonly UtilidadesConsola UtilsConsola = new();
    private static readonly List<Cliente> Clientes = new();
    
    private static int _idClienteActual;
        
    private static void Main(string[] args)
    {
        CargarDatosIniciales();
        
        int opcion;
        do
        {
            opcion = UtilsConsola.SolicitarOpcion();
            EjecutarOpcion(opcion);
        } while (opcion != 0);
    }

    private static void CargarDatosIniciales()
    {
        bool inicializarDatos = UtilsConsola.SolicitarBool("Cargar datos iniciales? S/N: ");
        
        if (inicializarDatos)
        {
            Clientes.Add(new Cliente()
            {
                NumeroCliente = 0,
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = "juan.perez@falso.com",
                FechaNacimiento = new DateTime(1985,3,1)
            });
            
            Clientes.Add(new Cliente()
            {
                NumeroCliente = 1,
                Nombre = "Bruno",
                Apellido = "Yorda",
                Email = "bruno.yorda@falso.com",
                FechaNacimiento = new DateTime(1990,7,7)
            });
            
            Clientes.Add(new Cliente()
            {
                NumeroCliente = 2,
                Nombre = "Peperino",
                Apellido = "Pomoro",
                Email = "peperino@falso.com",
                FechaNacimiento = new DateTime(1991,10,28)
            });

            _idClienteActual = 3;
        }
    }
    
    private static void EjecutarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                NuevoCliente();
                break;
            case 2:
                MostrarClientes();
                break;
            case 0:
                Console.WriteLine("Programa finalizado!\n");
                break;
            default:
                Console.WriteLine("Opción inválida!\n");
                break;
        }
    }
    
    private static void NuevoCliente()
    {
        Clientes.Add(new Cliente()
        {
            NumeroCliente = _idClienteActual++,
            Nombre = UtilsConsola.SolicitarString("Nombre: "),
            Apellido = UtilsConsola.SolicitarString("Apellido: "),
            FechaNacimiento = UtilsConsola.SolicitarFecha("Fecha de nacimiento (dd/mm/aaaa): "),
            Email = UtilsConsola.SolicitarString("Email: ", UtilsConsola.EmailRegex)
        });
        
        Console.WriteLine();
    }

    private static void MostrarClientes()
    {
        var encabezado = $"{"ID",5}|{" Nombre ",10}|{" Apellido ",10}|{" Fecha nac. ",12}|{"Email",10}";
        Console.WriteLine(encabezado);
        
        foreach (var cliente in Clientes)
        {
            Console.WriteLine(cliente.ToString());
        }
        
        Console.WriteLine();
    }
}
