using System.Text.RegularExpressions;

namespace A5_E3.EJ1;

public class UtilidadesConsola
{
    public string SolicitarString(string texto, Regex? regex = null, string[]? valoresAceptados = null)
    {
        Console.Write(texto);
        var input = Console.ReadLine();

        bool inputValido = false;
        while (!inputValido)
        {
            if (string.IsNullOrEmpty(input))
            {
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
                Console.Write("Ingrese un valor aceptado!: ");
                input = Console.ReadLine();
                continue;
            }
            
            inputValido = true;
        }
            
        return input;
    }
    
    public double SolicitarDouble(string texto)
    {
        var input = SolicitarString(texto);
        
        double entero = 0;
        if (!string.IsNullOrEmpty(input))
        {
            double.TryParse(input, out entero);
        }

        return entero;
    }
    
    public int SolicitarInt(string texto)
    {
        var input = SolicitarString(texto);
        
        int entero = 0;
        if (!string.IsNullOrEmpty(input))
        {
            int.TryParse(input, out entero);
        }

        return entero;
    }
}