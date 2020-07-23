using System;
using System.ComponentModel.DataAnnotations;

namespace gradeamento_backend.Api.Models
{
    public class GradeamentoInclusao
    {
        
        public string codigo { get; set; }
        
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Orientador { get; set; }

        public string Data { get; set; }
        
        public string Resumo { get; set; }

    }
}