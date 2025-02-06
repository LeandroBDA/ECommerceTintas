using ECommerceTintas.Models.Enum;
using ECommerceTintas.Models.Validators;

namespace ECommerceTintas.Models.Produtos;

public class ProdutoModel
{
    public int Id { get; init; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public ETipoCategoriaProduto Tipo { get; set; }
    public string Fabricante { get; set; } = null!;
    public int CodigoProduto { get; set; }
    public DateOnly? DataDeValidade { get; set; }
    
    public bool Validar(out List<string> erros)
    {
        var validator = new ProdutoValidation();
        var validationResult = validator.Validate(this);

        erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        return validationResult.IsValid;
    }
}
