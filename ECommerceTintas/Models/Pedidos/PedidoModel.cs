using ECommerceTintas.Models.Usuario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Models.Pedidos
{
    public class PedidoModel
    {
        [Key]
        public int Id { get; set; } // Identificador único do pedido
        
        [Required]
        public int UsuarioId { get; set; } // FK do usuário que fez o pedido
        
        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; } = null!; // Relacionamento com usuário
        
        [Required]
        public DateTime DataPedido { get; set; } = DateTime.Now; // Data do pedido
        
        [Required]
        public decimal ValorTotal { get; set; } // Soma do preço dos produtos no pedido
        
        [Required]
        public EStatusPedido Status { get; set; } // Status do pedido (Pendente, Pago, Cancelado)
        
        public List<ItemPedidoModel> Itens { get; set; } = new(); // Lista de itens no pedido
    }
}
