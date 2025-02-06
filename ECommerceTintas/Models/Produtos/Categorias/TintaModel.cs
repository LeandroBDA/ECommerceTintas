namespace ECommerceTintas.Models.Produto;
    public class TintaModel : ProdutoModel
    {
        public string TipoTinta { get; set; } = null!;
        public string Cor { get; set; } = null!; 
        public string Base { get; set; } = null!;
        public bool UsoExterno { get; set; }
        public int RendimentoPorLitro { get; set; } 
    }
