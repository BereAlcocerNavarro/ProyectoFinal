using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class UnionAlumnoMateria
    {
        public int Id { get; set; }
        public Alumno Alumno { get; set; } = null!;
        public Materia Materia { get; set; } = null!;
    }
}
