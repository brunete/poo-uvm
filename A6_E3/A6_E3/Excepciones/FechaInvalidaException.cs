namespace A6_E3.Excepciones;

public class FechaInvalidaException : Exception
{
    public FechaInvalidaException(string message) : base(message)
    {
    }
    
    public static FechaInvalidaException ConFechas(DateTime minFecha, DateTime maxFecha)
    {
        string message = $"Fecha inválida, no puede ser previa al {minFecha.ToString("dd/MM/yyyy")}, ni posterior al {maxFecha.ToString("dd/MM/yyyy")}!";
        return new FechaInvalidaException(message);
    }
}