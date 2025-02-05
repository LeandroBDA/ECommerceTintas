using ECommerceTintas.Models;
using ECommerceTintas.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("ListarClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClentes()
        {
            var cliente = await _clienteInterface.ListarClentes();
            return Ok(cliente);
        }

        [HttpPost("CadastrarCliente")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> CadastrarCliente([FromForm] ClienteModel novoCliente)
        {
            var resposta = await _clienteInterface.CadastrarCliente(novoCliente);
            return Ok(resposta);
        }

        [HttpPut("AtualizarCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> AtualizarCliente([FromForm] ClienteModel atualizarCliente, Guid idCliente)
        {
            var resposta = await _clienteInterface.AtualizarCliente(atualizarCliente, idCliente);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> ExcluirCliente(Guid idCliente)
        {
            var resposta = await _clienteInterface.ExcluirCliente(idCliente);
            return Ok(resposta);
        }
    }
}