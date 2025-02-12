using ECommerceTintas.Models.MaterialDePintura;
using ECommerceTintas.Models.Validators.Produtos;
using FluentValidation;

namespace ECommerceTintas.Models.Validators.MaterialDePinturaValidation;
public class MaterialDePinturaValidation : AbstractValidator<MaterialDePinturaModel>
{
    public MaterialDePinturaValidation()
    {
        Include(new ProdutoValidation()); 
        
        RuleFor(material => material.Tamanho)
            .NotEmpty().WithMessage("O tamanho do material é obrigatório.")
            .MaximumLength(50).WithMessage("O tamanho deve ter no máximo 50 caracteres.");
        
        RuleFor(material => material.Material)
            .MaximumLength(100).WithMessage("O material deve ter no máximo 100 caracteres.");
        
        RuleFor(material => material.IndicacaoUso)
            .MaximumLength(200).WithMessage("A indicação de uso deve ter no máximo 200 caracteres.");
        
        RuleFor(material => material.QuantidadePorPacote)
            .GreaterThan(0).WithMessage("A quantidade por pacote deve ser maior que zero.");
        
        RuleFor(material => material.Compatibilidade)
            .MaximumLength(150).WithMessage("A compatibilidade deve ter no máximo 150 caracteres.");
    }
}
