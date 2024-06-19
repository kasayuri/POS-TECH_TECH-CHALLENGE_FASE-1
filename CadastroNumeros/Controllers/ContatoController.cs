
using CadastroNumeros.Implementations;
using CadastroNumeros.Interfaces;
using CadastroNumeros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CadastroNumeros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoCadastro _contatoCadastro;
        public ContatoController(IContatoCadastro contatoCadastro)
        {
            _contatoCadastro = contatoCadastro;
        }

        [HttpGet("Contato")]
        public IActionResult Get() 
        {
            return Ok(_contatoCadastro.ListarContatos());
        }

        [HttpPost("inserirContato")]
        public IActionResult PostInserirContato([FromBody] Contato contato) 
        {
            _contatoCadastro.CriarContato(contato);
            return Ok(contato);
        }
        [HttpPut("atualizacaoContato")]
        public IActionResult PutAtualizacaoContato([FromBody] Contato contato)
        {
            return NoContent();
        }
        [HttpDelete("deleteContato")]
        public IActionResult DeleteCadastro(string idContato)
        {
            return NoContent();
        }
    }
}
