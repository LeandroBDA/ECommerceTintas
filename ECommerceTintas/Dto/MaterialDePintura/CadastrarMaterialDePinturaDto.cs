using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.MaterialDePintura
{
    public class CadastrarMaterialDePinturaDto
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string Fabricante { get; set; } = null!;
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
