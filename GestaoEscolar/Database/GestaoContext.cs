using GestaoEscolar.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoEscolar.API.Database
{
    public class GestaoContext : DbContext
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
           
        }

    }
}
