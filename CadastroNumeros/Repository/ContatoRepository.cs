using CadastroNumeros.Interfaces;
using CadastroNumeros.Models;

namespace CadastroNumeros.Implementations;

public class ContatoRepository : IContatoCadastro
{
    public IList<Contato> listaContato { get; set; }
    public ContatoRepository()
    {
        this.listaContato = new List<Contato>();
    }

    /// <summary>
    /// Método responsavel por cadastrar um usuário no banco de dados
    /// </summary>
    /// <param name="contato">Objeto do tipo Contato</param>
    /// <returns>Objeto do tipo Contato com as informações
    /// cadastradas no banco de dados
    /// </returns>
    public Contato CriarContato(Contato contato)
    {
        contato.Id = listaContato.Select(x => x.Id).Any() ? listaContato.Select(x => x.Id).Max() + 1 : 1;
        listaContato.Add(contato);
        return contato;
    }

    /// <summary>
    /// Método responsável por retornar um usuário de acordo com o ID
    /// </summary>
    /// <param name="id">Id do Contato</param>
    /// <returns>Retornar um objeto do tipo usuário 
    /// com as informações cadastradas no banco
    /// /returns>
    public Contato RetornarContato(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Método resposável por retornar todos os usuários cadastrados no banco de dados
    /// </summary>
    /// <returns>Lista de objetos do tipo Contato</returns>
    public IEnumerable<Contato> ListarContatos()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Método responsável por atualizar as informações de um contato no banco de dados
    /// </summary>
    /// <param name="contato">Um objeto do tipo Contato</param>
    public void AtualizarContato(Contato contato)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Método resposável por excluir um contato do banco de dados
    /// </summary>
    /// <param name="Id">Id do Contato</param>
    public void DeletarContato(int Id)
    {
        throw new NotImplementedException();
    }
}