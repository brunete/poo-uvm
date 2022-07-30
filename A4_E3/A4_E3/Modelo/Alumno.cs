namespace A4_E3.Modelo;

public class Alumno : Usuario
{
    public int Semestre { get; set; }

    public List<Materia> Materias { get; set; }

    public void AgregarMateria(Materia materia)
    {
        throw new NotImplementedException();
    }
}