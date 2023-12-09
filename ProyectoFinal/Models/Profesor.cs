using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public string? Telefono { get; set; }
        public string? Turno { get; set; }
    }
}
