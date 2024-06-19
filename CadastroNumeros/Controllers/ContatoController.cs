
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
        public ContatoController(IContatoCadastro _contatoCadastro)
        {
            _contatoCadastro = _contatoCadastro;
        }

        [HttpGet("Contato")]
        public IActionResult Get(IServiceProvider serviceProvider, int id) 
        {
            var contatoCadastro = serviceProvider.GetRequiredService<IContatoCadastro>();
            return Ok();
        }

        [HttpPost("inserirContato")]
        public IActionResult Post(IServiceProvider serviceProvider, Contato contato) 
        {
            var contatoCadastro = serviceProvider.GetRequiredService<IContatoCadastro>();
            contatoCadastro.CriarContato(contato);
            return Ok(contato);
        }
        
    }
}
