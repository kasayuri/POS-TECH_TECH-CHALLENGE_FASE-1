using CadastroNumeros.Domain.Interfaces.Repository;
using CadastroNumeros.Domain.Interfaces.Service;
using CadastroNumeros.Domain.Models;

namespace CadastroNumeros.Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task AtualizarContato(Contato contato)
        {
            await _contatoRepository.AtualizarContato(contato);
        }

        public async Task<Contato> CriarContato(Contato contato)
        {
            contato.DataCriacao = DateTime.Now;
            var contatoCriado = await _contatoRepository.CriarContato(contato);

            return contatoCriado;
        }

        public async Task DeletarContato(int Id)
        {
            await _contatoRepository.DeletarContato(Id);
        }

        public async Task<IEnumerable<Contato>> ListarContatos()
        {
            return await _contatoRepository.ListarContatos();
        }

        public async Task<Contato> RetornarContato(int id)
        {
            return await _contatoRepository.RetornarContato(id);
        }
    }
}
