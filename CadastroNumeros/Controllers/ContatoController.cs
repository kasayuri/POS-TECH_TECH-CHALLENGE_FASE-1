
using CadastroNumeros.Data;
using CadastroNumeros.Implementations;
using CadastroNumeros.Interfaces;
using CadastroNumeros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CadastroNumeros.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _repository;
    public ContatoController(IContatoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("retornar-contatos")]
    public ActionResult<IEnumerable<Contato>> GetAll() 
    {
        return Ok(_repository.ListarContatos());
    }

    [HttpGet("retornar-contato/{id}")]
    public ActionResult GetById(int id)
    {
        var contatoEncontrado = _repository.RetornarContato(id);
        if (contatoEncontrado != null)
        {
            return Ok(contatoEncontrado);
        }
        else return NotFound();
    }
    [HttpPost("inserir-contato")]
    public IActionResult PostInserirContato([FromBody] Contato contato) 
    {
        if (contato == null) 
        { 
            return BadRequest("Contato não pode ser nulo");
        }
        try
        {
            _repository.CriarContato(contato);
            return CreatedAtAction(nameof(GetById), new { id = contato.Id}, contato);
        }
        catch (Exception ex) 
        {   
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("atualizar-contato")]
    public IActionResult PutAtualizacaoContato([FromBody] Contato contato)
    {
        if (contato == null)
        {
            return BadRequest("Contato não pode ser nulo");
        }
        try
        {
         _repository.AtualizarContato(contato); 
         return Ok(contato);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("delete-contato/{id}")]
    public IActionResult DeleteCadastro(int idContato)
    {
        try
        {
            var contatoEncontrado = _repository.RetornarContato(idContato);
            if (contatoEncontrado == null)
            {
                return NotFound("Contato não encontrado");
            }
            _repository.DeletarContato(idContato);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }
}