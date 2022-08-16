using System.Text.RegularExpressions;

namespace A8_E3.Utils;

public class UtilidadesConsola
{
    public void MostrarMenuPrincipal()
    {
        Console.WriteLine("== Actividad 6 - Menú Principal ==");
        Console.WriteLine("1. Operaciones de ALUMNOS");
        Console.WriteLine("2. Operaciones de PROFESORES");
        Console.WriteLine("3. Operaciones de MATERIAS");
        Console.WriteLine("4. Salir");
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