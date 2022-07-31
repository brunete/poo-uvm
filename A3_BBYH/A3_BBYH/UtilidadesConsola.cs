﻿using System.Globalization;
using System.Text.RegularExpressions;

namespace A3_BBYH;

public class UtilidadesConsola
{
    public readonly Regex FechaRegex = new("^(0?[1-9]|[12][0-9]|3[01])[\\/\\-](0?[1-9]|1[012])[\\/\\-]\\d{4}$");
    public readonly Regex EmailRegex = new("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
    
    public int SolicitarOpcion()
    {
        MostrarMenu();
        Console.Write("Elija una opción: ");
        var input = Console.ReadLine();
        Console.WriteLine();
            
        int opcion = 0;
            
        if (!string.IsNullOrEmpty(input))
        {
            int.TryParse(input, out opcion);
        }

        return opcion;
    }
    
    private void MostrarMenu()
    {
        Console.WriteLine("== Actividad 3 - Menú ==");
        Console.WriteLine("1. Nuevo cliente");
        Console.WriteLine("2. Mostrar clientes");
        Console.WriteLine("3. Salir");
    }

    public string SolicitarString(string texto, Regex? regex = null)
    {
        Console.Write(texto);
        var input = Console.ReadLine();

        bool inputValido = false;
        while (!inputValido)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.Write("Ingrese un texto!: ");
                input = Console.ReadLine();
                continue;
            }
                
            if (regex != null && !regex.IsMatch(input))
            {
                Console.Write("Formato inválido!: ");
                input = Console.ReadLine();
                continue;
            }

            inputValido = true;
        }
            
        return input;
    }
    
    public DateTime SolicitarFecha(string texto, DateTime minFecha, DateTime maxFecha)
    {
        var fechaStr = SolicitarString(texto, FechaRegex);
        var fecha = DateTime.Parse(fechaStr);

        if (fecha < minFecha || fecha > maxFecha)
        {
            // Para este caso, una mejor práctica sería crear una excepción personalizada que herede de Exception.
            throw new Exception($"Fecha inválida, no puede ser previa al {minFecha.ToString("dd/mm/yyyy")}, ni posterior al {maxFecha.ToString("dd/mm/yyyy")}!"); 
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