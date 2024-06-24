using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
	public class QROperationController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(string value)
		{
			using (MemoryStream memory = new MemoryStream())
			{
				QRCodeGenerator qrGenerator = new QRCodeGenerator();
				QRCodeGenerator.QRCode qrCode = qrGenerator
					.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
				using (Bitmap image = qrCode.GetGraphic(10))
				{

					image.Save(memory, ImageFormat.Png);
					ViewBag.QRCodeImage = "data:image/png;base64," +
						Convert.ToBase64String(memory.ToArray());
				}
			}
			return View();
		}
	}
}
