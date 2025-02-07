using ECommerceTintas.Dto.ItemPedido;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Pedidos;

namespace ECommerceTintas.Services.ItemPedido
{
    public interface IItemPedidoInterface
    {
        Task<ResponseModel<List<ItemPedidoDto>>> ObterListaDeItensPedido();
        Task<ResponseModel<ItemPedidoModel>> BuscarItemPedidoPorId(int idItemPedido);
        Task<ResponseModel<ItemPedidoModel>> CadastrarItemPedido(CadastrarItemPedidoDto novoItemPedido);
        Task<ResponseModel<ItemPedidoModel>> ExcluirItemPedido(int idItemPedido);
        Task<ResponseModel<ItemPedidoModel>> AtualizarItemPedido(AtualizarItemPedidoDto atualizarItemPedido, int idItemPedido);
    }
}
