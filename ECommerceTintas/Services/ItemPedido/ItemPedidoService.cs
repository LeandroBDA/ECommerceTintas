using ECommerceTintas.Data;
using ECommerceTintas.Dto.ItemPedido;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Pedidos;
using Microsoft.EntityFrameworkCore;


namespace ECommerceTintas.Services.ItemPedido
{
    public class ItemPedidoService : IItemPedidoInterface
    {
        private readonly AppDbContext _context;

        public ItemPedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ItemPedidoDto>>> ObterListaDeItensPedido()
        {
            var resposta = new ResponseModel<List<ItemPedidoDto>>();
            try
            {
                var itens = await _context.ItensPedido.ToListAsync();
                resposta.Dados = itens.Select(item => new ItemPedidoDto
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario
                }).ToList();

                resposta.Mensagem = "Itens do pedido listados com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ItemPedidoModel>> CadastrarItemPedido(CadastrarItemPedidoDto novoItemPedido)
        {
            var resposta = new ResponseModel<ItemPedidoModel>();
            try
            {
                var item = new ItemPedidoModel
                {
                    ProdutoId = novoItemPedido.ProdutoId,
                    Quantidade = novoItemPedido.Quantidade,
                    PrecoUnitario = novoItemPedido.PrecoUnitario
                };

                await _context.ItensPedido.AddAsync(item);
                await _context.SaveChangesAsync();

                resposta.Dados = item;
                resposta.Mensagem = "Item do pedido cadastrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ItemPedidoModel>> AtualizarItemPedido(AtualizarItemPedidoDto atualizarItemPedido, int idItemPedido)
        {
            var resposta = new ResponseModel<ItemPedidoModel>();
            try
            {
                var item = await _context.ItensPedido.FindAsync(idItemPedido);
                if (item == null)
                {
                    resposta.Mensagem = "Item do pedido não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                item.Quantidade = atualizarItemPedido.Quantidade;
                item.PrecoUnitario = atualizarItemPedido.PrecoUnitario;

                _context.ItensPedido.Update(item);
                await _context.SaveChangesAsync();

                resposta.Dados = item;
                resposta.Mensagem = "Item do pedido atualizado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ItemPedidoModel>> ExcluirItemPedido(int idItemPedido)
        {
            var resposta = new ResponseModel<ItemPedidoModel>();
            try
            {
                var item = await _context.ItensPedido.FindAsync(idItemPedido);
                if (item == null)
                {
                    resposta.Mensagem = "Item do pedido não encontrado";
                    resposta.status = false;
                    return resposta;
                }

                _context.ItensPedido.Remove(item);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Item do pedido excluído com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<ItemPedidoModel>> BuscarItemPedidoPorId(int idItemPedido)
        {
            throw new NotImplementedException();
        }
    }
}
