using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class ProyectoFinalContext : DbContext
    {
        public ProyectoFinalContext (DbContextOptions<ProyectoFinalContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoFinal.Models.Profesor> Profesor { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.Alumno> Alumno { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.Materia> Materia { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.Calificacion> Calificacion { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.AlumnoMateria> AlumnoMateria { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.ProfesorMateria> ProfesorMateria { get; set; } = default!;

        public DbSet<ProyectoFinal.Models.UnionAlumnoMateria> UnionAlumnoMateria { get; set; } = default!;
    }
}
