using Microsoft.AspNetCore.Mvc;
using SistemaImobiliario.Application.Usuarios;
using SIstemaImobiliario.Repository;
using SIstemaImobiliario.Repository.Models;

namespace SistemaImobiliario.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ContextTab _context;
        public UsuarioController(ContextTab context)
        {
            _context = context;
        }

        [HttpPost]

        public IActionResult InserirUsuario([FromBody] UsuarioRequest request)
        {
            var usuarioService = new UsuarioService(_context);
            var sucesso = usuarioService.InserirUsuario(request);

            if (sucesso == true) {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]

        public IActionResult ObterUsuarios()
        {
            var usuarioService = new UsuarioService(_context);
            var sucesso = usuarioService.ObterUsuarios();

            try
            {
                return Ok(sucesso);
            }

            catch
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult AtualizarUsuario([FromRoute] int id, [FromBody] UsuarioRequest request)
        {
            var usuarioService = new UsuarioService(_context);
            var sucesso = usuarioService.AtualizarUsuario(id, request);
            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            var usuarioService = new UsuarioService(_context);
            var sucesso = usuarioService.DeletarUsuario(id);
            if(sucesso == true)
            {
                return NoContent();
            }
            else { return BadRequest(); }
        }
           
}
    }

