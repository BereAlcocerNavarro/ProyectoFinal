﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Creditos { get; set; }
    }
}
