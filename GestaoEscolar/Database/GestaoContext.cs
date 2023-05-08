using GestaoEscolar.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.API.Database
{
    public class GestaoContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GestaoEscolar;Integrated Security=True;");
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>().HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });
            modelBuilder.Entity<AlunoDisciplina>().HasOne(a => a.Aluno).WithMany(a => a.AlunoDisciplina).HasForeignKey(fk=>fk.AlunoId);
            modelBuilder.Entity<AlunoDisciplina>().HasOne(ad => ad.Disciplina).WithMany(d => d.AlunoDisciplina).HasForeignKey(ad => ad.DisciplinaId);
        }
    }
}
