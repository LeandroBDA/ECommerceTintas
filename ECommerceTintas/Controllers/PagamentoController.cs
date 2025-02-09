using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.ComponentModel.DataAnnotations;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        public enum MetodoPagamento
        {
            [Display(Name = "1 - Pix")]
            Pix = 1,
    
            [Display(Name = "2 - Boleto")]
            Boleto = 2,
    
            [Display(Name = "3 - Cartão")]
            Cartao = 3
        }

        [HttpPost("FormaDePagamento")]
        public IActionResult SimularPagamento([FromBody] PagamentoRequest request)
        {
            if (!Enum.IsDefined(typeof(MetodoPagamento), request.Metodo))
            {
                return BadRequest("Método de pagamento inválido");
            }

            var resposta = new PagamentoResponse
            {
                Metodo = request.Metodo.ToString(),
                Detalhes = $"Pagamento via {request.Metodo} processado com sucesso"
            };

            switch (request.Metodo)
            {
                case MetodoPagamento.Pix:
                    resposta.Detalhes = "Código PIX gerado com sucesso";
                    resposta.QrCodeBase64 = GerarQrCodeBase64("00020126330014BR.GOV.BCB.PIX0114+5511999999999204000053039865802BR5920Nome" +
                                                              " Empresa6009-Programacao.Orientada.a.Objetos IFCE-62070503***6304ABCD");
                    break;

                case MetodoPagamento.Boleto:
                    resposta.Detalhes = "Boleto gerado com sucesso. Número: 12345678901234567890";
                    break;

                case MetodoPagamento.Cartao:
                    resposta.Detalhes = "Pagamento com cartão de crédito autorizado.";
                    break;
            }

            if (request.Metodo == MetodoPagamento.Pix)
            {
                var qrCodeImagem = GerarQrCodeImagem("00020126330014BR.GOV.BCB.PIX0114+5511999999999204000053039865802BR5920Nome" +
                                                     " Empresa6009-Programacao.Orientada.a.Objetos IFCE-62070503***6304ABCD");
                return qrCodeImagem; 
            }

            return Ok(resposta);
        }

        private string GerarQrCodeBase64(string pixPayload)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(pixPayload, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeBytes = qrCode.GetGraphic(20);
                return Convert.ToBase64String(qrCodeBytes);
            }
        }

        private IActionResult GerarQrCodeImagem(string pixPayload)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(pixPayload, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeBytes = qrCode.GetGraphic(10); 
                return File(qrCodeBytes, "image/png"); 
            }
        }
    }

    public class PagamentoRequest
    {
        [Required]
        [EnumDataType(typeof(PagamentoController.MetodoPagamento))]
        public PagamentoController.MetodoPagamento Metodo { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0.")]
        public double Valor { get; set; }

        public DateOnly? Vencimento { get; set; } 
    }

    public class PagamentoResponse
    {
        public string Metodo { get; set; }
        public string Detalhes { get; set; }
        public string QrCodeBase64 { get; set; }
    }
}
