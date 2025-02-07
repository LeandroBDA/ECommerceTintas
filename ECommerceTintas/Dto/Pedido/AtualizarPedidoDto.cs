namespace ECommerceTintas.Dto.Pedido
{
    public class AtualizarPedidoDto
    {
        public string Status { get; set; } = string.Empty;
        public string EnderecoEntrega { get; set; } = string.Empty;
        public string FormaPagamento { get; set; } = string.Empty;
    }
}
