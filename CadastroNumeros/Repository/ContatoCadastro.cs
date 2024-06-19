using CadastroNumeros.Interfaces;
using CadastroNumeros.Models;

namespace CadastroNumeros.Implementations;

public class ContatoCadastro : IContatoCadastro
{
    public IList<Contato> listaContato { get; set; }
    public ContatoCadastro()
    {
        this.listaContato = new List<Contato>();
    }
    public Contato CriarContato(Contato contato)
    {
        contato.Id = listaContato.Select(x => x.Id).Any() ? listaContato.Select(x => x.Id).Max() + 1 : 1;
        listaContato.Add(contato);
        return contato;
    }

    public Contato RetornarContato(int id)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<Contato> ListarContatos()
    {
        throw new NotImplementedException();
    }

    public void AtualizarContato(Contato contato)
    {
        throw new NotImplementedException();
    }

    public void DeletarContato(int Id)
    {
        throw new NotImplementedException();
    }
}