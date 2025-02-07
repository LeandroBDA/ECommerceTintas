using ECommerceTintas.Models.Pedidos;
using FluentValidation;



namespace ECommerceTintas.Models.Validators
{
    public class PedidoValidation : AbstractValidator<PedidoModel>
    {
        public PedidoValidation()
        {
            RuleFor(pedido => pedido.UsuarioId)
                .GreaterThan(0).WithMessage("O ID do cliente é obrigatório e deve ser válido.");

            RuleFor(pedido => pedido.DataPedido)
                .NotEmpty().WithMessage("A data do pedido é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data do pedido não pode ser no futuro.");

            RuleFor(pedido => pedido.ValorTotal)
                .GreaterThan(0).WithMessage("O valor total do pedido deve ser maior que zero.");

            RuleFor(pedido => pedido.Status)
                .IsInEnum().WithMessage("O status do pedido deve ser válido.");
        }
    }
}
