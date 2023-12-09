using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public int IdMateria { get; set; }
        [Display(Name = "Calificación")]
        public decimal Score {  get; set; }  
    }
}
