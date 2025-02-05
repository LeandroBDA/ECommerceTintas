namespace ECommerceTintas.Models;

public class ResponseModel <T>
{
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = String.Empty;
    public bool status { get; set; } = true;
    public List<string> Erros { get; set; } = new List<string>();
}