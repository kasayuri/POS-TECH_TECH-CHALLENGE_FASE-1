using CadastroNumeros.Domain.Interfaces.Repository;
using CadastroNumeros.Domain.Models;
using CadastroNumeros.Infra.Data;
using Microsoft.EntityFrameworkCore;

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
    public async Task<Contato> CriarContato(Contato contato)
    {
        await _context.AddAsync(contato);
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
    public async Task<Contato> RetornarContato(int id)
    {
        return await _context.Contatos.FindAsync(id);
    }

    /// <summary>
    /// Método resposável por retornar todos os usuários cadastrados no banco de dados
    /// </summary>
    /// <returns>Lista de objetos do tipo Contato</returns>
    public async Task<IEnumerable<Contato>> ListarContatos()
    {
        return await _context.Contatos.ToListAsync();
    }

    /// <summary>
    /// Método responsável por atualizar as informações de um contato no banco de dados
    /// </summary>
    /// <param name="contato">Um objeto do tipo Contato</param>
    public async Task AtualizarContato(Contato contato)
    {
        var contatoSalvo = await _context.Contatos.FindAsync(contato.Id);

        contatoSalvo.DDDId = contato.DDDId;
        contatoSalvo.Endereco = contato.Endereco;
        contatoSalvo.Idade = contato.Idade;
        contatoSalvo.Nome = contato.Nome;
        contatoSalvo.NumeroTel = contato.NumeroTel;

        _context.SaveChanges();
    }

    /// <summary>
    /// Método resposável por excluir um contato do banco de dados
    /// </summary>
    /// <param name="Id">Id do Contato</param>
    public async Task DeletarContato(int Id)
    {
        var contatoEncontrado = await _context.Contatos.FindAsync(Id);
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