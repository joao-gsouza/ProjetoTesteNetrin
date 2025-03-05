using Microsoft.AspNetCore.Mvc;
using ProjetoTeste.Models.Conversor;
using ProjetoTeste.Models.Request;
using ProjetoTeste.Models.Response;
using ProjetoTeste.Models.Sistema;
using ProjetoTeste.Service.Consultas.Cliente;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoTeste.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<ClienteResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultaTodosOsClientes()
        {
            try
            {
                var result = await _clienteService.ConsulteLista();

                if (result.Count <= 0)
                {
                    return NoContent();
                }

                return Ok(ClienteConversor.EntityListToReponseList(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Erro(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultaClientePorId(int id)
        {
            try
            {
                var result = await _clienteService.ConsultaPorId(id);

                if (result is null)
                {
                    return NoContent();
                }

                return Ok(ClienteConversor.EntityToResponse(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Erro(ex.Message));
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InsereCliente([FromBody] ClienteRequest cliente)
        {
            try
            {
                var result = await _clienteService.Inserir(cliente);

                if (result is null)
                {
                    return NoContent();
                }

                return Created(string.Empty, ClienteConversor.EntityToResponse(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Erro(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var result = await _clienteService.Deletar(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Erro(ex.Message));
            }
        }

        [HttpPut()]
        [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarCliente([FromBody] ClienteUpdateRequest cliente)
        {
            try
            {
                var result = await _clienteService.Atualizar(cliente);

                if (result is null)
                {
                    return NoContent();
                }

                return Ok(ClienteConversor.EntityToResponse(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Erro(ex.Message));
            }
        }
    }
}
