using gradeamento_backend.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace gradeamento_backend.Api.DbContexts
{
    public class GradeamentoContext : DbContext
    {
        public GradeamentoContext()
        {

        }
     
        public GradeamentoContext(DbContextOptions<GradeamentoContext> options)
           : base(options)
        {

        }

        public DbSet<Gradeamento> Gradeamentos { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          

            base.OnModelCreating(modelBuilder);
        }

    }
}
