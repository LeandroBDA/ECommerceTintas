using ECommerceTintas.Dto.ItemPedido;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Pedidos;
using ECommerceTintas.Services.ItemPedido;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoInterface _itemPedidoInterface;

        public ItemPedidoController(IItemPedidoInterface itemPedidoInterface)
        {
            _itemPedidoInterface = itemPedidoInterface;
        }

        [HttpGet("ListarItensPedido")]
        public async Task<ActionResult<ResponseModel<List<ItemPedidoDto>>>> ListarItensPedido()
        {
            var resposta = await _itemPedidoInterface.ObterListaDeItensPedido();
            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }

        [HttpPost("AdicionarItemPedido")]
        public async Task<ActionResult<ResponseModel<ItemPedidoModel>>> AdicionarItemPedido([FromBody] CadastrarItemPedidoDto itemPedidoDto)
        {
            var resposta = await _itemPedidoInterface.CadastrarItemPedido(itemPedidoDto);
            if (!resposta.status)
            {
                return BadRequest(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }

        [HttpGet("BuscarItemPedidoPorId/{idItem}")]
        public async Task<ActionResult<ResponseModel<ItemPedidoDto>>> BuscarItemPedidoPorId(int idItem)
        {
            try
            {
                var resposta = await _itemPedidoInterface.BuscarItemPedidoPorId(idItem);
                if (!resposta.status)
                {
                    return NotFound(new { mensagem = resposta.Mensagem });
                }

                return Ok(resposta);
            }
            catch (NotImplementedException)
            {
                return NotFound(new { mensagem = "Método ainda não implementado." });
            }
        }

        [HttpPut("AtualizarItemPedido/{idItem}")]
        public async Task<ActionResult<ResponseModel<ItemPedidoModel>>> AtualizarItemPedido([FromBody] AtualizarItemPedidoDto atualizarItemPedido, int idItem)
        {
            var resposta = await _itemPedidoInterface.AtualizarItemPedido(atualizarItemPedido, idItem);
            if (!resposta.status)
            {
                return BadRequest(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }

        [HttpDelete("ExcluirItemPedido/{idItem}")]
        public async Task<ActionResult<ResponseModel<ItemPedidoModel>>> ExcluirItemPedido(int idItem)
        {
            var resposta = await _itemPedidoInterface.ExcluirItemPedido(idItem);
            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }
    }
}
