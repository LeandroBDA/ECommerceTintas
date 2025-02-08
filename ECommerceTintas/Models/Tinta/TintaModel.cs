using ECommerceTintas.Models.Enum;
using ECommerceTintas.Models.Produtos;

namespace ECommerceTintas.Models.Tinta;
    public class TintaModel : ProdutoModel
    {
        public int Id { get; set; }
        public ETipoDeTinta TipoDeTinta { get; set; }
        public string Cor { get; set; } = null!; 
        public string Base { get; set; } = null!;
        public bool UsoExterno { get; set; }
        public int RendimentoPorLitro { get; set; } 
    }
