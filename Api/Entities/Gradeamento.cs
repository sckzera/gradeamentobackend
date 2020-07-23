using System;
using System.ComponentModel.DataAnnotations;

namespace gradeamento_backend.Api.Entities
{
    public class Gradeamento
    {
        [Key]
        public Guid IdGradeamento { get; set; }

        [Required]
        public string codigo { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Orientador { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string Resumo { get; set; }

    }
}