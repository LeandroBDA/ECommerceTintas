using ECommerceTintas.Dto.ItemPedido;
namespace ECommerceTintas.Dto.Pedido
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } = new();
        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
        public string EnderecoEntrega { get; set; } = string.Empty;
        public string FormaPagamento { get; set; } = string.Empty;
        public DateTime DataPedido { get; set; }
    }
}
