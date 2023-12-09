using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class ProfesorMateria
    {
        public int Id { get; set; }
        [Display(Name = "ID de la Materia")]
        public int IdMateria { get; set; }
        [Display(Name = "ID del Profesor")]
        public int IdProfesor { get; set; }
    }
}
