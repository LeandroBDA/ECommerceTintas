using ECommerceTintas.Models.Pedidos;
using FluentValidation;

namespace ECommerceTintas.Models.Validators.ItemPedidos
{
    public class ItemPedidoValidation : AbstractValidator<ItemPedidoModel>
    {
        public ItemPedidoValidation()
        {
            RuleFor(item => item.PedidoId)
                .GreaterThan(0).WithMessage("O ID do pedido é obrigatório e deve ser válido.");

            RuleFor(item => item.ProdutoId)
                .GreaterThan(0).WithMessage("O ID do produto é obrigatório e deve ser válido.");

            RuleFor(item => item.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do item deve ser maior que zero.");

            RuleFor(item => item.PrecoUnitario)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");
        }
    }
}
