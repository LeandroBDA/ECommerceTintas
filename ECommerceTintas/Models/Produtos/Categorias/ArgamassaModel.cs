namespace ECommerceTintas.Models.Produto;
    public class ArgamassaModel : ProdutoModel
    {
    public string TipoArgamassa { get; set; } = null!; 
    public bool UsoExterno { get; set; } 
    public int TempoCura { get; set; } 
    public int Peso { get; set; } 
    }
