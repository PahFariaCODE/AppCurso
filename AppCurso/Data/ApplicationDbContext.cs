using AppCurso.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppCurso.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        // Incluir DbSet para cada entidade do modelo

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turams { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoTurma> AlunoTurmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }


}
