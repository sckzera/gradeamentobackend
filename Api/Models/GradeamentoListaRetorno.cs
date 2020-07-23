using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using gradeamento_backend.Api.Entities;

namespace gradeamento_backend.Api.Models
{
    public class GradeamentoListaRetorno
    {
        public List<GradeamentoConsulta> resultado { get; set; }
    }
}