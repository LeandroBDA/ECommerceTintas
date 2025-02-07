using ECommerceTintas.Models.Usuario;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Models.Pedidos
{
    public class PedidoModel
    {
        [Key]
        public int Id { get; set; } 
        
        [Required]
        public int UsuarioId { get; set; } 
        
        [ForeignKey("UsuarioId")]
        public UsuarioModel Usuario { get; set; } = null!; 
        
        [Required]
        public DateTime DataPedido { get; set; } = DateTime.Now; 
        
        [Required]
        public decimal ValorTotal { get; set; } 
        
        [Required]
        public EStatusPedido Status { get; set; } 
        
        public List<ItemPedidoModel> Itens { get; set; } = new(); 
    }
}
