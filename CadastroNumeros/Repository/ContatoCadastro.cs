using CadastroNumeros.Interfaces;
using CadastroNumeros.Models;

namespace CadastroNumeros.Implementations
{
    public class ContatoCadastro : IContatoCadastro
    {
        private readonly IBancoDados _bancoDados;
        public ContatoCadastro(IBancoDados bancoDados)
        {
            _bancoDados = bancoDados;
        }

        public Contato CriarContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Contato RetornarContato(int id)
        {
            throw new NotImplementedException();
        }
    }
}
