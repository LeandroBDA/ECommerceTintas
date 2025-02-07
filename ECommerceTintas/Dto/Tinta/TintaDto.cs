using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.Tinta
{
    public class TintaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string Fabricante { get; set; } = null!;
        public ETipoDeTinta TipoDeTinta { get; set; }
        public string Cor { get; set; } = null!;
        public string Base { get; set; } = null!;
        public bool UsoExterno { get; set; }
        public int RendimentoPorLitro { get; set; }
    }
}
