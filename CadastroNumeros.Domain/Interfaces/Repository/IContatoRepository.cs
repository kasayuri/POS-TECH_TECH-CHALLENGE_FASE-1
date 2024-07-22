using CadastroNumeros.Domain.Models;

namespace CadastroNumeros.Domain.Interfaces.Repository
{
    public interface IContatoRepository
    {
        public Task<IEnumerable<Contato>> ListarContatos();
        public Task<Contato> RetornarContato(int id);
        public Task<Contato> CriarContato(Contato contato);
        public Task AtualizarContato(Contato contato);
        public Task DeletarContato(int Id);
    }
}
