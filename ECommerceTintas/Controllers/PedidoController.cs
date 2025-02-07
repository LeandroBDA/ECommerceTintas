using ECommerceTintas.Dto.Pedido;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Pedidos;
using ECommerceTintas.Services.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoInterface _pedidoInterface;

        public PedidoController(IPedidoInterface pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ListarPedidos()
        {
            var pedidos = await _pedidoInterface.ObterListaDePedidos();
            return Ok(pedidos);
        }

        [HttpPost("CadastrarPedido")]
        public async Task<ActionResult<ResponseModel<PedidoModel>>> CadastrarPedido([FromBody] CadastrarPedidoDto pedidoDto)
        {
            var resposta = await _pedidoInterface.CadastrarPedido(pedidoDto);
            return Ok(resposta);
        }

        [HttpGet("BuscarPedidoPorId/{idPedido}")]
        public async Task<ActionResult<ResponseModel<PedidoDto>>> BuscarPedidoPorId(int idPedido)
        {
            var resposta = await _pedidoInterface.BuscarPedidoPorId(idPedido);

            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }

        [HttpPut("AtualizarPedido/{idPedido}")]
        public async Task<ActionResult<ResponseModel<PedidoModel>>> AtualizarPedido([FromBody] AtualizarPedidoDto atualizarPedido, int idPedido)
        {
            var resposta = await _pedidoInterface.AtualizarPedido(atualizarPedido, idPedido);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirPedido/{idPedido}")]
        public async Task<ActionResult<ResponseModel<PedidoModel>>> ExcluirPedido(int idPedido)
        {
            var resposta = await _pedidoInterface.ExcluirPedido(idPedido);
            return Ok(resposta);
        }
    }
}
