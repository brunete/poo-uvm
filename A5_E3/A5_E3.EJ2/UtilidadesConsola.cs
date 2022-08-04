namespace A5_E3.EJ2;

public class UtilidadesConsola
{
    public string SolicitarString(string texto, string[]? valoresAceptados = null)
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
    
    public int SolicitarEntero(string texto)
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