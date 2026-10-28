namespace AppCurso.Models
{
    public class Turma
    {
        public int Id { get; set; } // Chave primária (Primary Key)
        public string Nome { get; set; }
        public int CursoId { get; set; } // Chave estrangeira (Foreign Key)
        public Curso? Curso { get; set; } // Propriedade de navegação

    }
}
