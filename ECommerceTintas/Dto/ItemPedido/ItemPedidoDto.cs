namespace ECommerceTintas.Dto.Pedido
{
    public class ItemPedidoDto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal => PrecoUnitario * Quantidade;
    }
}
