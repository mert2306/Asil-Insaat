using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Asil_Insaat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IYaziService yaziService;

        public HomeController(ILogger<HomeController> logger, IYaziService yaziService)
        {
            _logger = logger;
            this.yaziService = yaziService;
        }

        public async Task<IActionResult> Index()
        {
            var yazis = await yaziService.TümYazilarıGetirAsync();
            return View(yazis);
        }
        public async Task<IActionResult> Detay()
        {
            var yazis = await yaziService.SilinmemisTümYaziVeKategorileriGetirAsync();
           
            return View(yazis);
        }
        public async Task<IActionResult> Hakkimizda()
        {
            return View();
        }
        public async Task<IActionResult> Incele(Guid id)
        {
            var yazi = await yaziService.SilinmemisYaziVeKategorileriGetirAsync(id);
            return View(yazi);

        }
        public async Task<IActionResult> Referans()
        {
            return View();
        }
        public  IActionResult Iletisim()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Iletisim(Mail m)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); 
                client.Credentials = new NetworkCredential("asilinsaatyapiyalitim@gmail.com", "mevo ozyb nael ximr");
                client.EnableSsl = true;
                MailMessage msj = new MailMessage(); 
                msj.From = new MailAddress(m.Email, m.AdiSoyadi); 
                msj.To.Add("asilinsaatyapiyalitim@gmail.com"); 
                msj.Subject = m.Konu + "" + m.Email; 
                msj.Body = m.Mesaj; 
                client.Send(msj); 
                MailMessage msj1 = new MailMessage();
                msj1.From = new MailAddress("asilinsaatyapiyalitim@gmail.com", "Asil İnşaat Yapı & Yalıtım");
                msj1.To.Add(m.Email); 
                msj1.Subject = "Mesaj Talebiniz";
                msj1.Body = "Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz! Size En kısa zamanda Döneceğiz. ";
                client.Send(msj1);
                ViewBag.Succes = "Teşekkürler Mailniz başarı bir şekilde gönderildi"; 
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Mesaj Gönderilken hata oluştu";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}