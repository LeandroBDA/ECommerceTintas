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
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> CadastrarProduto(
            [FromForm] CadastrarProdutoDto produtoDto,
            IFormFile? imagem)
        {
            if (imagem != null)
            {
                string imagemUrl = await SalvarImagem(imagem);
                produtoDto.ImagemUrl = imagemUrl;
            }

            var resposta = await _produtoInterface.CadastrarProduto(produtoDto, imagem);
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
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> AtualizarProduto(
            [FromForm] AtualizarProdutoDto atualizarProduto,
            int idProduto,
            IFormFile? imagem)
        {
            if (imagem != null)
            {
                string imagemUrl = await SalvarImagem(imagem);
                atualizarProduto.ImagemUrl = imagemUrl;
            }

            var resposta = await _produtoInterface.AtualizarProduto(atualizarProduto, idProduto, imagem);
            return Ok(resposta);
        }

        [HttpDelete("ExcluirProduto/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> ExcluirProduto(int idProduto)
        {
            var resposta = await _produtoInterface.ExcluirProduto(idProduto);
            return Ok(resposta);
        }

        private async Task<string> SalvarImagem(IFormFile imagem)
        {
            var pastaDestino = Path.Combine("wwwroot", "imagens");
            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
            string caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await imagem.CopyToAsync(stream);
            }

            return $"/imagens/{nomeArquivo}"; 
        }
    }
}
