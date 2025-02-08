using ECommerceTintas.Dto.Produto;
using ECommerceTintas.Models.Enum;

namespace ECommerceTintas.Dto.Tinta
{
    public class CadastrarTintaDto : CadastrarProdutoDto
    {
        public ETipoDeTinta TipoDeTinta { get; set; }
        public string Cor { get; set; } = null!;
        public string Base { get; set; } = null!;
        public bool UsoExterno { get; set; }
        public int RendimentoPorLitro { get; set; }
    }
}
