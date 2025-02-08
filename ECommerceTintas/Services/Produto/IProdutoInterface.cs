using ECommerceTintas.Dto.Produto;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Produtos;

namespace ECommerceTintas.Services.Produto
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<ProdutoDto>>> ObterListaDeProdutos();
        Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto);
        Task<ResponseModel<ProdutoModel>> CadastrarProduto(CadastrarProdutoDto novoProduto,  IFormFile? imagem);
        Task<ResponseModel<ProdutoModel>> ExcluirProduto(int idProduto);
        Task<ResponseModel<ProdutoModel>> AtualizarProduto(AtualizarProdutoDto atualizarProduto, int idProduto, IFormFile? imagem);
    }
}
