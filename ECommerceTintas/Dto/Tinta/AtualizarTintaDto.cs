using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.Tinta
{
    public class AtualizarTintaDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? QuantidadeEmEstoque { get; set; }
        public string? Fabricante { get; set; }
        public ETipoDeTinta? TipoDeTinta { get; set; }
        public string? Cor { get; set; }
        public string? Base { get; set; }
        public bool? UsoExterno { get; set; }
        public int? RendimentoPorLitro { get; set; }
    }
}
