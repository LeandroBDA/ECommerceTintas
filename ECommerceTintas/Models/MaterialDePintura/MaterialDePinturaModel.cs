using ECommerceTintas.Models.Enum;
using ECommerceTintas.Models.Produtos;

namespace ECommerceTintas.Models.MaterialDePintura;

    public class MaterialDePinturaModel : ProdutoModel
{
    public int Id { get; set; }
    public ETipoCategoriaProduto TipoDeMaterialDeTinta { get; set; } 
    public string Tamanho { get; set; } = null!; 
    public string? Material { get; set; } 
    public string? IndicacaoUso { get; set; } 
    public bool? Reutilizavel { get; set; } 
    public string? Cor { get; set; } 
    public int QuantidadePorPacote { get; set; }
    public string? Compatibilidade { get; set; } 
}