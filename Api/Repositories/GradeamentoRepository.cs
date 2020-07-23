

using System;
using System.Collections.Generic;
using System.Linq;
using gradeamento_backend.Api.DbContexts;
using gradeamento_backend.Api.Entities;

namespace gradeamento_backend.Api.Repositories
{
    public class GradeamentoRepository : IGradeamentoRepository, IDisposable
    {
         private readonly GradeamentoContext _context;

        public GradeamentoRepository(GradeamentoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Cadastrar(Gradeamento gradeamentos)
        {
            if (gradeamentos == null)
            {
                throw new ArgumentNullException(nameof(gradeamentos));
            }

            gradeamentos.IdGradeamento = Guid.NewGuid();

            _context.Gradeamentos.Add(gradeamentos);
        }

        public Gradeamento Obter(Guid codigo)
        {
            if (codigo == Guid.Empty)
                throw new ArgumentNullException(nameof(codigo));

            return _context.Gradeamentos
                .Where(c => c.IdGradeamento == codigo)
                .FirstOrDefault();
        }

        public void Excluir(Guid codigo)
        {
            if (codigo == Guid.Empty)
                throw new ArgumentNullException(nameof(codigo));

            var veiculo = _context.Gradeamentos.Where(q => q.IdGradeamento == codigo).First();

            _context.Gradeamentos.Remove(veiculo);
        }

        public bool Salvar()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Alterar(Gradeamento gradeamento)
        {
            if (gradeamento == null)
                throw new ArgumentNullException(nameof(gradeamento));

            if (gradeamento.IdGradeamento == Guid.Empty)
                throw new ArgumentNullException(nameof(gradeamento.IdGradeamento));

            var oldGradeamento = Obter(gradeamento.IdGradeamento);

            if (oldGradeamento == null)
                throw new NullReferenceException(nameof(oldGradeamento));

            _context.Gradeamentos.Update(oldGradeamento).CurrentValues.SetValues(gradeamento);
        }

        // Verifica se o GUID informado existe no banco de dados
        public bool Existe(Guid codigo)
        {
            if (codigo == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(codigo));
            }
            return _context.Gradeamentos.Any(a => a.IdGradeamento == codigo);
        }

        public List<Gradeamento> Obter()
        {
            List<Gradeamento> retorno = new List<Gradeamento>();

            var lista = from s in _context.Gradeamentos
                           select s;
            
            var listaOrdenada = lista.OrderBy(c => c.Titulo);

            foreach(var item in listaOrdenada){
                retorno.Add(item);
            }

            return retorno;
        }
    }
}