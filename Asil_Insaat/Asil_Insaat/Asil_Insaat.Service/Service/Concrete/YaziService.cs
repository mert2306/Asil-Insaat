using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Yazis;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Helpers.Resims;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class YaziService : IYaziService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IResimHelper resimHelper;
        private readonly ClaimsPrincipal kullanici;

        public YaziService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IResimHelper resimHelper)

        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            kullanici = httpContextAccessor.HttpContext.User;
            this.resimHelper = resimHelper;
        }

        public async Task<YaziListeViewModel> SayfaYazilariniGetirAsync(Guid kategoriId, int currentPage = 1, int pageSize = 3, bool isAscending = false)

        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var yazis = kategoriId == null
                ? await unitOfWork.GetRepository<Yazi>().GetAllAsync(s => !s.SilinmisMi, s => s.Kategori, i => i.Resim, u => u.User)
                : await unitOfWork.GetRepository<Yazi>().GetAllAsync(s => s.KategoriId == kategoriId && !s.SilinmisMi, f => f.Kategori, i => i.Resim, u => u.User);
      
            return new YaziListeViewModel
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                IsAscending = isAscending

            };
        }

        public async Task<List<YaziViewModel>> SilimisTümYaziVeKategorileriGetirAsync()
        {
            var Yazis = await unitOfWork.GetRepository<Yazi>().GetAllAsync(x => x.SilinmisMi, x => x.Kategori);
            var map = mapper.Map<List<YaziViewModel>>(Yazis);

            return map;
        }

        public async Task<List<YaziViewModel>> SilinmemisTümYaziVeKategorileriGetirAsync()
        {
            var yazilar = await unitOfWork.GetRepository<Yazi>().GetAllAsync(x => !x.SilinmisMi, x => x.Kategori, r=> r.Resim);
            var map = mapper.Map<List<YaziViewModel>>(yazilar);

            return map;
        }

        public async Task<YaziViewModel> SilinmemisYaziVeKategorileriGetirAsync(Guid yaziId)
        {
            var yazi = await unitOfWork.GetRepository<Yazi>().GetAsync(x => !x.SilinmisMi && x.Id == yaziId, x => x.Kategori, i => i.Resim);
            var map = mapper.Map<YaziViewModel>(yazi);

            return map;
        }

        public async Task<List<Yazi>> TümYazilarıGetirAsync()
        {
            return await unitOfWork.GetRepository<Yazi>().GetAllAsync();
        }

        public async Task<string> YaziGüncelleAsync(YaziGüncellemeViewModel yaziGüncellemeViewModel)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var yazi = await unitOfWork.GetRepository<Yazi>().GetAsync(x => !x.SilinmisMi && x.Id == yaziGüncellemeViewModel.Id, x => x.Kategori, i => i.Resim);

            if (yaziGüncellemeViewModel.Fotograf != null)
            {
                resimHelper.Delete(yazi.Resim.FileName);
                var resimGüncelle = await resimHelper.Upload(yaziGüncellemeViewModel.Baslik, yaziGüncellemeViewModel.Fotograf, ResimType.Post);
                Resim resim = new(resimGüncelle.TamIsim, yaziGüncellemeViewModel.Fotograf.ContentType, userEmail);
                await unitOfWork.GetRepository<Resim>().AddAsync(resim);

                yazi.ResimId = resim.Id;
            }

            yazi.Baslik = yaziGüncellemeViewModel.Baslik;
            yazi.KategoriId = yaziGüncellemeViewModel.KategoriId;
            yazi.Icerik = yaziGüncellemeViewModel.Icerik;
           

            await unitOfWork.GetRepository<Yazi>().UpdateAsync(yazi);
            await unitOfWork.SaveAsync();

            return yazi.Baslik;
        }

        public async Task<string> YaziGüvenliSilmeAsync(Guid yaziId)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var yazi = await unitOfWork.GetRepository<Yazi>().GetByGuidAsync(yaziId);

            yazi.SilinmisMi = true;
            yazi.Silen = userEmail;
            await unitOfWork.GetRepository<Yazi>().UpdateAsync(yazi);
            await unitOfWork.SaveAsync();

            return yazi.Baslik;
        }

        public async Task YaziOlusturAsync(YaziEklemeViewModel yaziEklemeViewModel)
        {
            var userId = kullanici.GetLoggedInUserId();
            var userEmail = kullanici.GetLoggedInEmail();

            var resimYükleme = await resimHelper.Upload(yaziEklemeViewModel.Baslik, yaziEklemeViewModel.Fotograf, ResimType.Post);
            Resim resim = new(resimYükleme.TamIsim, yaziEklemeViewModel.Fotograf.ContentType, userEmail);
            await unitOfWork.GetRepository<Resim>().AddAsync(resim);

            var yazi = new Yazi(yaziEklemeViewModel.Baslik, yaziEklemeViewModel.Icerik, userId, userEmail, yaziEklemeViewModel.KategoriId, resim.Id);


            await unitOfWork.GetRepository<Yazi>().AddAsync(yazi);
            await unitOfWork.SaveAsync();
        }

        public async Task<string> YaziGüvenliGetirAsync(Guid yaziId)
        {
            var yazi = await unitOfWork.GetRepository<Yazi>().GetByGuidAsync(yaziId);

            yazi.SilinmisMi = false;
            yazi.Silen = null;
            await unitOfWork.GetRepository<Yazi>().UpdateAsync(yazi);
            await unitOfWork.SaveAsync();

            return yazi.Baslik;
        }

        public Task<YaziListeViewModel> SayfaYazilariniGetirAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            throw new NotImplementedException();
        }
    }
}
