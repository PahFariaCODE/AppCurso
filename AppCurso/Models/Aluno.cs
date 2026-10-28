namespace AppCurso.Models
{
    public class Aluno
    {
        public int Id { get; set; } //Chave Primária (Primary Key)
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
