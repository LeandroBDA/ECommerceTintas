using ECommerceTintas.Models.Usuario;
using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Models.Pedidos
{
    public class PedidoModel
    {
        public int Id { get; set; } 
        public int UsuarioId { get; set; } 
        public UsuarioModel Usuario { get; set; } = null!; 
        public DateTime DataPedido { get; set; } = DateTime.Now; 
        public decimal ValorTotal { get; set; } 
        public EStatusPedido Status { get; set; } 
        public List<ItemPedidoModel> Itens { get; set; } = new(); 
    }
}
