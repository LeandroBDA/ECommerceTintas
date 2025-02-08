using ECommerceTintas.Models.Enum;
using ECommerceTintas.Dto.Produto;


namespace ECommerceTintas.Dto.MaterialDePintura
{
    public class MaterialDePinturaDto : ProdutoDto
    {
        public ETipoCategoriaProduto TipoDeMaterialDeTinta { get; set; }
        public string Tamanho { get; set; } = null!;
        public string? Material { get; set; }
        public string? IndicacaoUso { get; set; }
        public bool? Reutilizavel { get; set; }
        public string? Cor { get; set; }
        public int QuantidadePorPacote { get; set; }
        public string? Compatibilidade { get; set; }
    }
}
