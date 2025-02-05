using ECommerceTintas.Dto.Cliente;
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
        public async Task<ActionResult<ResponseModel<ClienteModel>>> CadastrarCliente([FromBody] CadastrarClienteDto clienteDto)
        {
            var resposta = await _clienteInterface.CadastrarCliente(clienteDto);
            return Ok(resposta);
        }
        
        [HttpGet("BuscarClientePorId/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteDto>>> BuscarClientePorId(Guid idCliente)
        {
            var resposta = await _clienteInterface.BuscarClientePorId(idCliente);

            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }


        [HttpPut("AtualizarCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> AtualizarCliente([FromForm] AtualizarClienteDto atualizarCliente, Guid idCliente)
        {
            var resposta = await _clienteInterface.AtualizarCliente(atualizarCliente, idCliente);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirCliente/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> ExcluirCliente(ExcluirClienteDto idCliente)
        {
            var resposta = await _clienteInterface.ExcluirCliente(idCliente);
            return Ok(resposta);
        }
    }
}