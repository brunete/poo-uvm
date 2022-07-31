namespace A3_BBYH;

internal class Program
{
    private static readonly UtilidadesConsola UtilsConsola = new();
    private static readonly List<Cliente> Clientes = new();
    
    // Usado para validación de fechas de nacimiento y para demostrar manejo de excepciones.
    // Elección Arbitraria, 120 años en el pasado.
    private static readonly DateTime MinFechaNacimiento = DateTime.Now.Subtract(TimeSpan.FromDays(43800)); // 120 x 365
    
    private static int _idClienteActual;
        
    private static void Main(string[] args)
    {
        CargarDatosIniciales();
        
        int opcion;
        do
        {
            opcion = UtilsConsola.SolicitarOpcion();
            EjecutarOpcion(opcion);
        } while (opcion != 3);
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
            case 3:
                Console.WriteLine("Programa finalizado!\n");
                break;
            default:
                Console.WriteLine("Opción inválida!\n");
                break;
        }
    }
    
    private static void NuevoCliente()
    {
        var cliente = new Cliente()
        {
            NumeroCliente = _idClienteActual++,
            Nombre = UtilsConsola.SolicitarString("Nombre: "),
            Apellido = UtilsConsola.SolicitarString("Apellido: "),
            Email = UtilsConsola.SolicitarString("Email: ", UtilsConsola.EmailRegex)
        };

        bool fechaOk = false;
        do
        {
            try
            {
                var fechaNacimiento = UtilsConsola.SolicitarFecha("Fecha de nacimiento (dd/mm/aaaa): ", MinFechaNacimiento, DateTime.Now);
                cliente.FechaNacimiento = fechaNacimiento;
                fechaOk = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } while (!fechaOk);
        
        Clientes.Add(cliente);
        Console.WriteLine();
    }

    private static void MostrarClientes()
    {
        if (Clientes.Count > 0)
        {
            var encabezado = $"{"ID",5}|{" Nombre ",10}|{" Apellido ",10}|{" Fecha nac. ",12}|{"Email",10}";
            Console.WriteLine(encabezado);
            
            foreach (var cliente in Clientes)
            {
                Console.WriteLine(cliente.ToString());
            }    
        }
        else
        {
            Console.WriteLine("No hay clientes registrados!");
        }
        
        Console.WriteLine();
    }
}
