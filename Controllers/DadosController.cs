using Microsoft.AspNetCore.Mvc;
using SistemaImobiliario.Application.Cliente;
using SIstemaImobiliario.Repository;
using SIstemaImobiliario.Repository.Models;

namespace CorretoraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DadosController : ControllerBase
    {
        private readonly ContextTab _context;

        public DadosController(ContextTab context)
        {
            _context = context;
        }

        [HttpGet]
        public List<TabDadosPesquisa> ObterPesquisas()
        {
            var ObterPesquisasClientes = new ClienteService(_context);
            var sucesso = ObterPesquisasClientes.ObterPesquisas();

            return sucesso;
        }

        [HttpPost]

        public IActionResult  InserirDados([FromBody] ClienteRequest request)
        {
            var InserirDadosPesquisa = new ClienteService(_context);
            var sucesso = InserirDadosPesquisa.InserirDados(request);

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
