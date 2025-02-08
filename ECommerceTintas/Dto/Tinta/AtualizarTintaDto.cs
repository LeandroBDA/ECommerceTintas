using ECommerceTintas.Dto.Produto;
using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.Tinta
{
    public class AtualizarTintaDto : ProdutoDto
    {
         public ETipoDeTinta? TipoDeTinta { get; set; }
        public string? Cor { get; set; }
        public string? Base { get; set; }
        public bool? UsoExterno { get; set; }
        public int? RendimentoPorLitro { get; set; }
    }
}
