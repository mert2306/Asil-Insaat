using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{

    [Area("Admin")]

    public class KategoriController : Controller
    {
        private readonly IKategoriService kategoriService;
        private readonly IValidator<Kategori> validator;
        private readonly IMapper mapper;

        public KategoriController(IKategoriService kategoriService, IValidator<Kategori> validator, IMapper mapper)
        {
            this.kategoriService = kategoriService;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var kategoriler = await kategoriService.SilinmemisTümKategorileriGetir();
            return View(kategoriler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Ekle(KategoriEklemeViewModel kategoriEklemeViewModel)
        {
            var map = mapper.Map<Kategori>(kategoriEklemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                await kategoriService.KategoriOlusturAsync(kategoriEklemeViewModel);
                return RedirectToAction("Index", "Kategori", new { Area = "Admin" });

            }


            result.AddToModelState(this.ModelState);

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(Guid kategoriId)
        {
            var kategori = await kategoriService.KategoriGetirByGuid(kategoriId);
            var map = mapper.Map<Kategori, KategoriGüncellemeViewModel>(kategori);
            return View(map);
        }
      
        [HttpPost]
        public async Task<IActionResult> Güncelle(KategoriGüncellemeViewModel kategoriGüncellemeViewModel)
        {
            var map = mapper.Map<Kategori>(kategoriGüncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await kategoriService.KategoriGüncelleAsync(kategoriGüncellemeViewModel);
                return RedirectToAction("Index", "Kategori", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            return View(kategoriGüncellemeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> KategoriSil()
        {
            var kategoriler = await kategoriService.TümSilinmisKAtegorileriGetir();
            return View(kategoriler);
        }
        
        
        public async Task<IActionResult> Sil(Guid kategoriId)
        {

            var isim = await kategoriService.KategorileriGüvenliSilAsync(kategoriId);


            return RedirectToAction("Index", "Kategori", new { Area = "Admin" });

        }


        public async Task<IActionResult> GeriSilme(Guid kategoriId)
        {

            var isim = await kategoriService.SilinenKategoriGeriGetirAsync(kategoriId);


            return RedirectToAction("Index", "Kategori", new { Area = "Admin" });

        }


    }
}
