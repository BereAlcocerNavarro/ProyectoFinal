using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class AlumnoMateria
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public int IdAlumno { get; set; }
    }
}
