using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Microsoft.AspNetCore.Http;

namespace Asil_Insaat.Entity.ViewModels.Yazis
{
    public class YaziGüncellemeViewModel
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public Guid KategoriId { get; set; }

        public Resim Resim { get; set; }

        public IFormFile? Fotograf { get; set; }

        public IList<KategoriViewModel> Kategoris { get; set; }
    }
}
