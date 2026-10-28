namespace AppCurso.Models
{
    public class AlunoTurma
    {
        public int Id { get; set; } // Chave primária (Primary Key
        public int AlunoId { get; set; } // Chave estrangeira (Foreign Key)
        public Aluno? Aluno { get; set; } // Propriedade de navegação
        public int TurmaId { get; set; } // Chave estrangeira (Foreign Key)
        public Turma? Turma { get; set; } // Propriedade de navegação

    }
}
