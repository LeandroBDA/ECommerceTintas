using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace ECommerceTintas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : ControllerBase
    {
        [HttpGet("gerarQrCode")]
        public IActionResult GerarQrCode(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return BadRequest("O texto do QR Code não pode ser vazio.");

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
                using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeBytes = qrCode.GetGraphic(20);

                    return File(qrCodeBytes, "image/png");
                }
            }
        }
    }
}