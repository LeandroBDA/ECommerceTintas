using ECommerceTintas.Models.Produtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceTintas.Models.Pedidos
{
    public class ItemPedidoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; } 
        public PedidoModel Pedido { get; set; } = null!;
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; } = null!;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}
