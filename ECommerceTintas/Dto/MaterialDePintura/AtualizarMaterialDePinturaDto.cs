using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.MaterialDePintura
{
    public class AtualizarMaterialDePinturaDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? QuantidadeEmEstoque { get; set; }
        public string? Fabricante { get; set; }
        public ETipoCategoriaProduto? TipoDeMaterialDeTinta { get; set; }
        public string? Tamanho { get; set; }
        public string? Material { get; set; }
        public string? IndicacaoUso { get; set; }
        public bool? Reutilizavel { get; set; }
        public string? Cor { get; set; }
        public int? QuantidadePorPacote { get; set; }
        public string? Compatibilidade { get; set; }
    }
}
