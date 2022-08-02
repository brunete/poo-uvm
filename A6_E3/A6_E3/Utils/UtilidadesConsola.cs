using System.Text.RegularExpressions;
using A6_E3.Excepciones;

namespace A6_E3.Utils;

public class UtilidadesConsola
{
    public readonly Regex FechaRegex = new("^(0?[1-9]|[12][0-9]|3[01])[\\/\\-](0?[1-9]|1[012])[\\/\\-]\\d{4}$");
    
    public void MostrarMenuPrincipal()
    {
        Console.WriteLine("== Actividad 6 - Menú Principal ==");
        Console.WriteLine("1. Operaciones de ALUMNOS");
        Console.WriteLine("2. Operaciones de PROFESORES");
        Console.WriteLine("3. Operaciones de MATERIAS");
        Console.WriteLine("4. Salir");
    }
    
    public void MostrarMenuAlumnos()
    {
        Console.WriteLine("== Actividad 6 - Alumnos ==");
        Console.WriteLine("1. Nuevo");
        Console.WriteLine("2. Consultar");
        Console.WriteLine("3. Consultar materias");
        Console.WriteLine("4. Buscar");
        Console.WriteLine("5. Modificar");
        Console.WriteLine("6. Eliminar");
        Console.WriteLine("7. Volver al menú principal");
    }

    public void MostrarMenuProfesores()
    {
        Console.WriteLine("== Actividad 6 - Profesores ==");
        Console.WriteLine("1. Nuevo");
        Console.WriteLine("2. Consultar");
        Console.WriteLine("3. Buscar");
        Console.WriteLine("4. Modificar");
        Console.WriteLine("5. Eliminar");
        Console.WriteLine("6. Volver al menú principal");
    }

    public void MostrarMenuMaterias()
    {
        Console.WriteLine("== Actividad 6 - Materias ==");
        Console.WriteLine("1. Nueva");
        Console.WriteLine("2. Consultar");
        Console.WriteLine("3. Buscar");
        Console.WriteLine("4. Modificar");
        Console.WriteLine("5. Eliminar");
        Console.WriteLine("6. Volver al menú principal");
    }

    public string SolicitarString(string texto, Regex? regex = null, string[]? valoresAceptados = null)
    {
        if (!string.IsNullOrEmpty(texto)) 
            Console.Write(texto);
        
        var input = Console.ReadLine();

        bool inputValido = false;
        while (!inputValido)
        {
            if (string.IsNullOrEmpty(input))
            {
                if (!string.IsNullOrEmpty(texto)) 
                    Console.Write(texto);
                
                input = Console.ReadLine();
                continue;
            }
                
            if (regex != null && !regex.IsMatch(input))
            {
                Console.Write("Formato inválido!: ");
                input = Console.ReadLine();
                continue;
            }

            if (valoresAceptados != null && !valoresAceptados.Contains(input.ToUpper()))
            {
                Console.Write("Valor no aceptado!: ");
                input = Console.ReadLine();
                continue;
            }

            inputValido = true;
        }
            
        return input;
    }
    
    public int SolicitarEntero(string texto)
    {
        var input = SolicitarString(texto);
        Console.WriteLine();
        
        int entero = 0;
        if (!string.IsNullOrEmpty(input))
        {
            int.TryParse(input, out entero);
        }
        
        return entero;
    }
    
    public DateTime SolicitarFecha(string texto, DateTime? minFecha = null, DateTime? maxFecha = null)
    {
        var fechaStr = SolicitarString(texto, FechaRegex);
        var fecha = DateTime.Parse(fechaStr);

        if ((minFecha != null && fecha < minFecha) ||
            (maxFecha != null && fecha > maxFecha))
        {
            throw FechaInvalidaException.ConFechas(minFecha.Value, maxFecha.Value);           
        }
        
        return fecha;
    }

    public bool SolicitarBool(string texto)
    {
        string input;
        
        do
        {
            input = SolicitarString(texto);
        } while (input.ToUpper() != "S" && input.ToUpper() != "N");

        return string.Equals(input.ToUpper(), "S");
    }
}