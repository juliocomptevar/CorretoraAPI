using Microsoft.AspNetCore.Mvc;
using SistemaImobiliario.Applications;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SistemaImobiliario.Applications.Autenticacao;
using SIstemaImobiliario.Repository;

namespace CorretoraAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AutenticarController : ControllerBase
    {

        private readonly ContextTab _context;
        public AutenticarController(ContextTab context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoResquest request)
        {
            var autenticacaoService = new AutenticacaoService(_context);
            var resposta = autenticacaoService.Autenticar(request);

            if (resposta == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(resposta);
            }
        }
    }
}
        