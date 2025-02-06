using ECommerceTintas.Data;
using ECommerceTintas.Dto.Produto;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Produto;
using ECommerceTintas.Models.Validators;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ProdutoDto>>> ObterListaDeProdutos()
        {
            var resposta = new ResponseModel<List<ProdutoDto>>();
            try
            {
                var produtos = await _context.Produtos.ToListAsync();
                var produtoDto = produtos.Select(produto => new ProdutoDto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                    Categoria = produto.Categoria,  
                    Fabricante = produto.Fabricante,
                    CodigoProduto = produto.CodigoProduto,
                    DataDeValidade = produto.DataDeValidade
                }).ToList();

                resposta.Dados = produtoDto;
                resposta.Mensagem = "Todos os produtos foram listados";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProdutoModel>> BuscarProdutoPorId(int idProduto)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var produto = await _context.Produtos.FindAsync(idProduto);
                if (produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                resposta.Dados = produto;
                resposta.Mensagem = "Produto encontrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProdutoModel>> CadastrarProduto(CadastrarProdutoDto produtoDto)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var novoProduto = new ProdutoModel
                {
                    Nome = produtoDto.Nome,
                    Descricao = produtoDto.Descricao,
                    Preco = produtoDto.Preco,
                    QuantidadeEmEstoque = produtoDto.QuantidadeEmEstoque,
                    Categoria = produtoDto.Categoria,
                    Fabricante = produtoDto.Fabricante,
                    CodigoProduto = produtoDto.CodigoProduto,
                    DataDeValidade = produtoDto.DataDeValidade
                };

                var validator = new ProdutoValidation();
                var validationResult = validator.Validate(novoProduto);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                await _context.Produtos.AddAsync(novoProduto);
                await _context.SaveChangesAsync();

                resposta.Dados = novoProduto;
                resposta.Mensagem = "Produto cadastrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProdutoModel>> ExcluirProduto(int idProduto)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var produto = await _context.Produtos.FindAsync(idProduto);
                if (produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado para exclusão";
                    resposta.status = false;
                    return resposta;
                }

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = produto;
                resposta.Mensagem = "Produto excluído com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProdutoModel>> AtualizarProduto(AtualizarProdutoDto atualizarProduto, int idProduto)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var produtoExistente = await _context.Produtos.FindAsync(idProduto);
                if (produtoExistente == null)
                {
                    resposta.Mensagem = "Produto não encontrado para atualização";
                    resposta.status = false;
                    return resposta;
                }

                produtoExistente.Nome = atualizarProduto.Nome;
                produtoExistente.Descricao = atualizarProduto.Descricao;
                produtoExistente.Preco = atualizarProduto.Preco;
                produtoExistente.QuantidadeEmEstoque = atualizarProduto.QuantidadeEmEstoque;
                produtoExistente.Categoria = atualizarProduto.Categoria;
                produtoExistente.Fabricante = atualizarProduto.Fabricante;
                produtoExistente.CodigoProduto = atualizarProduto.CodigoProduto;
                produtoExistente.DataDeValidade = atualizarProduto.DataDeValidade;

                var validator = new ProdutoValidation();
                var validationResult = validator.Validate(produtoExistente);

                if (!validationResult.IsValid)
                {
                    resposta.Mensagem = "Erro de validação";
                    resposta.status = false;
                    resposta.Erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return resposta;
                }

                _context.Produtos.Update(produtoExistente);
                await _context.SaveChangesAsync();

                resposta.Dados = produtoExistente;
                resposta.Mensagem = "Produto atualizado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        Task<ResponseModel<List<ProdutoDto>>> IProdutoInterface.ObterListaDeProdutos()
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<ProdutoModel>> IProdutoInterface.BuscarProdutoPorId(int idProduto)
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<ProdutoModel>> IProdutoInterface.CadastrarProduto(CadastrarProdutoDto novoProduto)
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<ProdutoModel>> IProdutoInterface.ExcluirProduto(int idProduto)
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<ProdutoModel>> IProdutoInterface.AtualizarProduto(AtualizarProdutoDto atualizarProduto, int idProduto)
        {
            throw new NotImplementedException();
        }
    }
}
