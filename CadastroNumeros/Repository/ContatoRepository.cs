using CadastroNumeros.Data;
using CadastroNumeros.Interfaces;
using CadastroNumeros.Models;

namespace CadastroNumeros.Implementations;

public class ContatoRepository : IContatoRepository
{
    private readonly AppDbContext _context;
    public ContatoRepository(AppDbContext context)
    {
        _context = context;
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
        _context.Add(contato);
        _context.SaveChanges();
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
        return _context.Contatos.Find(id);
    }

    /// <summary>
    /// Método resposável por retornar todos os usuários cadastrados no banco de dados
    /// </summary>
    /// <returns>Lista de objetos do tipo Contato</returns>
    public IEnumerable<Contato> ListarContatos()
    {
        return _context.Contatos.ToList();
    }

    /// <summary>
    /// Método responsável por atualizar as informações de um contato no banco de dados
    /// </summary>
    /// <param name="contato">Um objeto do tipo Contato</param>
    public void AtualizarContato(Contato contato)
    {
        _context.Contatos.Update(contato);
        _context.SaveChanges();
    }

    /// <summary>
    /// Método resposável por excluir um contato do banco de dados
    /// </summary>
    /// <param name="Id">Id do Contato</param>
    public void DeletarContato(int Id)
    {
        var contatoEncontrado = _context.Contatos.Find(Id);
        if (contatoEncontrado != null)
        {
            _context.Remove(contatoEncontrado);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Contato não encontrado na base de dados");
        }
    }
}