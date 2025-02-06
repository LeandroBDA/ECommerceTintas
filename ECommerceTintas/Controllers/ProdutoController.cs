using ECommerceTintas.Dto.Produto;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Produtos;
using ECommerceTintas.Services.Produto;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;

        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet("ListarProdutos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListarProdutos()
        {
            var produtos = await _produtoInterface.ObterListaDeProdutos();
            return Ok(produtos);
        }

        [HttpPost("CadastrarProduto")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> CadastrarProduto([FromBody] CadastrarProdutoDto produtoDto)
        {
            var resposta = await _produtoInterface.CadastrarProduto(produtoDto);
            return Ok(resposta);
        }
        
        [HttpGet("BuscarProdutoPorId/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoDto>>> BuscarProdutoPorId(int idProduto)
        {
            var resposta = await _produtoInterface.BuscarProdutoPorId(idProduto);

            if (!resposta.status)
            {
                return NotFound(new { mensagem = resposta.Mensagem });
            }

            return Ok(resposta);
        }

        [HttpPut("AtualizarProduto/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> AtualizarProduto([FromForm] AtualizarProdutoDto atualizarProduto, int idProduto)
        {
            var resposta = await _produtoInterface.AtualizarProduto(atualizarProduto, idProduto);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirProduto/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> ExcluirProduto(int idProduto)
        {
            var resposta = await _produtoInterface.ExcluirProduto(idProduto);
            return Ok(resposta);
        }
    }
}
