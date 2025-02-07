using ECommerceTintas.Dto.ItemPedido;

namespace ECommerceTintas.Dto.Pedido
{
    public class CadastrarPedidoDto
    {
        public int UsuarioId { get; set; }
        public List<CadastrarItemPedidoDto> Itens { get; set; } = new();
        public string EnderecoEntrega { get; set; } = string.Empty;
        public string FormaPagamento { get; set; } = string.Empty;
    }
}
