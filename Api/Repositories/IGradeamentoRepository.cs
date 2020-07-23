using System;
using System.Collections.Generic;
using gradeamento_backend.Api.Entities;

namespace gradeamento_backend.Api.Repositories
{
    public interface IGradeamentoRepository
    {
        Gradeamento Obter(Guid codigo);
        List<Gradeamento> Obter();
        void Cadastrar(Gradeamento gradeamentos);
        void Alterar(Gradeamento gradeamentos);
        void Excluir(Guid codigo);
        bool Salvar();   
        bool Existe(Guid codigo);
    }
}