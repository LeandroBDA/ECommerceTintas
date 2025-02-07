using ECommerceTintas.Dto.Pedido;
using ECommerceTintas.Models;
using ECommerceTintas.Models.Pedidos;

namespace ECommerceTintas.Services.Pedido
{
    public interface IPedidoInterface
    {
        Task<ResponseModel<List<PedidoDto>>> ObterListaDePedidos();
        Task<ResponseModel<PedidoModel>> BuscarPedidoPorId(int idPedido);
        Task<ResponseModel<PedidoModel>> CadastrarPedido(CadastrarPedidoDto novoPedido);
        Task<ResponseModel<PedidoModel>> ExcluirPedido(int idPedido);
        Task<ResponseModel<PedidoModel>> AtualizarPedido(AtualizarPedidoDto atualizarPedido, int idPedido);
    }
}
