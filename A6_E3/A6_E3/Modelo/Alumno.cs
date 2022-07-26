﻿using A6_E3.Excepciones;

namespace A6_E3.Modelo;

public class Alumno : Usuario
{
    public int Semestre { get; set; }

    public List<Materia> Materias { get; }

    public Alumno()
    {
        Materias = new List<Materia>();
    }

    public void AgregarMateria(Materia materia)
    {
        if (materia.EsValida())
        {
            Materias.Add(materia);
        }
        else
        {
            throw new MateriaInvalidaException();
        }
    }

    public void ModificarDatos(Alumno alumno)
    {
        Semestre = alumno.Semestre != 0 ? alumno.Semestre : Semestre;
        base.ModificarDatos(alumno);
    }

    public new bool EsValido()
    {
        if (base.EsValido())
        {
            return true;
        }

        return false;
    }

    public string StringLineaTabla()
    {
        return
            $"{NumControlEscolar,10}|{Nombre,8}|{Apellido,10}|{Sexo,6}|{FechaNacimiento.ToString("dd/MM/yyyy"),12}|{Semestre,5}";
    }

    public string StringBusqueda()
    {
        return $"{Nombre} {Apellido} ({Edad}) | Sexo: {Sexo} | Semestre: {Semestre}";
    }
}