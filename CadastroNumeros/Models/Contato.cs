namespace CadastroNumeros.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Endereco { get; set; }
        public DDD DDD { get; set; }
        public Contato(int id, string nome, string idade, string endereco, DDD dDD)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Endereco = endereco;
            DDD = dDD;
        }
    }
}
