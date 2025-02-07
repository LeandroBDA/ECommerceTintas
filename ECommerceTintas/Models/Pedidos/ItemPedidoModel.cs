using ECommerceTintas.Models.Produtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceTintas.Models.Pedidos
{
    public class ItemPedidoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; } 

        [ForeignKey("PedidoId")]
        public PedidoModel Pedido { get; set; } = null!;

        [Required]
        public int ProdutoId { get; set; }
        
        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; } = null!;

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }
        
        [Required]
        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}
