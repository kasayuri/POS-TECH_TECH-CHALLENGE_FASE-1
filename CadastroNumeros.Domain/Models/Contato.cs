namespace CadastroNumeros.Domain.Models
{
    public class Contato
    {
        
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int NumeroTel { get; set; }
        public string Endereco { get; set; }
        public int DDD { get; set; }
        public virtual DDD _DDD { get; set; }

        public Contato() { }

        public Contato(int id, string nome, int idade, int numeroTel, string endereco, int dDD)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            NumeroTel = numeroTel;
            Endereco = endereco;
            DDD = dDD;
        }
        
    }
}
