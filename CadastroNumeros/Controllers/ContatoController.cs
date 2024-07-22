using CadastroNumeros.Domain.Interfaces.Service;
using CadastroNumeros.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroNumeros.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoService _service;
    public ContatoController(IContatoService service)
    {
        _service = service;
    }

    [HttpGet("retornar-contatos")]
    public async Task<IActionResult> GetAll() 
    {
        return Ok(await _service.ListarContatos());
    }

    [HttpGet("retornar-contato/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contatoEncontrado = await _service.RetornarContato(id);

        if (contatoEncontrado != null)
        {
            return Ok(contatoEncontrado);
        }
        else 
            return NotFound();
    }
    [HttpPost("inserir-contato")]
    public async Task<IActionResult> PostInserirContato([FromBody] Contato contato) 
    {
        if (contato == null) 
        { 
            return BadRequest("Contato não pode ser nulo");
        }
        try
        {   
            var contatoCriado = await _service.CriarContato(contato);
            return CreatedAtAction(nameof(GetById), new { id = contato.Id}, contato);
        }
        catch (Exception ex) 
        {   
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("atualizar-contato")]
    public async Task<IActionResult> PutAtualizacaoContato([FromBody] Contato contatoAtualizado)
    {
        if (contatoAtualizado == null)
        {
            return BadRequest("Todos os dados devem ser preenchidos");
        }
        try
        {
            var contatoRecuperado = await _service.RetornarContato(contatoAtualizado.Id);
            if(contatoRecuperado != null)
            {
                await _service.AtualizarContato(contatoRecuperado); 
                return Ok(contatoRecuperado);
            }
            else
            {
                return BadRequest("Contato não encontrado");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("delete-contato/{id}")]
    public async Task<IActionResult> DeleteCadastro(int idContato)
    {
        try
        {
            var contatoEncontrado = await _service.RetornarContato(idContato);
            if (contatoEncontrado == null)
            {
                return NotFound("Contato não encontrado");
            }
            await _service.DeletarContato(idContato);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }
}