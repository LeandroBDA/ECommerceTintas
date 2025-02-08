using ECommerceTintas.Dto.Produto;
using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.MaterialDePintura
{
    public class CadastrarMaterialDePinturaDto : CadastrarProdutoDto
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
