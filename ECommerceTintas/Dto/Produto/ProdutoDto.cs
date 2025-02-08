using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.Produto;

public class ProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public decimal? Preco { get; set; }
    public int? QuantidadeEmEstoque { get; set; }
    public string Fabricante { get; set; } = null!;
    public int CodigoProduto { get; set; }
    public DateOnly? DataDeValidade { get; set; }
    public ETipoCategoriaProduto Tipo { get; set; }
    public string ImagemUrl { get; set; } = null!;

}