using CadastroNumeros.Models;

namespace CadastroNumeros.Interfaces
{
    public interface IContatoCadastro
    {
        IList<Contato> listaContato { get; set; }
        public IEnumerable<Contato> ListarContatos();
        public Contato RetornarContato(int id);
        public Contato CriarContato(Contato contato);
        public void AtualizarContato(Contato contato);
        public void DeletarContato(int Id);
    }
}
