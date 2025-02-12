using ECommerceTintas.Models.Tinta;
using ECommerceTintas.Models.Validators.Produtos;
using FluentValidation;

namespace ECommerceTintas.Models.Validators.Tintas;
public class TintaValidation : AbstractValidator<TintaModel>
{
    public TintaValidation()
    {
        Include(new ProdutoValidation());
        
        RuleFor(tinta => tinta.Cor)
            .NotEmpty().WithMessage("A cor da tinta é obrigatória.")
            .MaximumLength(50).WithMessage("A cor deve ter no máximo 50 caracteres.");
        
        RuleFor(tinta => tinta.Base)
            .NotEmpty().WithMessage("A base da tinta é obrigatória.")
            .MaximumLength(50).WithMessage("A base deve ter no máximo 50 caracteres.");
        
        RuleFor(tinta => tinta.RendimentoPorLitro)
            .GreaterThan(0).WithMessage("O rendimento por litro deve ser maior que zero.");
    }
}
