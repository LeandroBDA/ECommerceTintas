using FluentValidation;
using ECommerceTintas.Models.Produto;

namespace ECommerceTintas.Models.Validators;
public class ProdutoValidation : AbstractValidator<ProdutoModel>
{
    public ProdutoValidation()
    {
        RuleFor(produto => produto.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .Length(3, 80).WithMessage("O nome deve ter entre 3 e 80 caracteres.");
        
        RuleFor(produto => produto.Descricao)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(300).WithMessage("A descrição deve ter no máximo 300 caracteres.");
        
        RuleFor(produto => produto.Preco)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        
        RuleFor(produto => produto.QuantidadeEmEstoque)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa.");
        
        RuleFor(produto => produto.Fabricante)
            .NotEmpty().WithMessage("O fabricante é obrigatório.")
            .MaximumLength(80).WithMessage("O fabricante deve ter no máximo 80 caracteres.");
        
        RuleFor(produto => produto.CodigoProduto)
            .GreaterThan(0).WithMessage("O código do produto deve ser válido.");
        
        RuleFor(produto => produto.DataDeValidade)
            .GreaterThan(DateOnly.FromDateTime(DateTime.Now)).When(p => p.DataDeValidade.HasValue)
            .WithMessage("A data de validade deve ser futura.");
    }
}