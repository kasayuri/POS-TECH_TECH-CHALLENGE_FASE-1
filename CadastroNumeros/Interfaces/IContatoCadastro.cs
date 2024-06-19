using CadastroNumeros.Models;

namespace CadastroNumeros.Interfaces
{
    public interface IContatoCadastro
    {
        public Contato RetornarContato(int id);
        public Contato CriarContato(Contato contato);
    }
}
