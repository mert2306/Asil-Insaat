using Asil_Insaat.Core.Veris;

namespace Asil_Insaat.Entity.Entities
{
    public class Yazi : VeriTabani
    {
        public Yazi()
        {


        }

        public Yazi(string baslik, string icerik, Guid userId, string olusturan, Guid kategoriId, Guid resimId)
        {
            Baslik = baslik;
            Icerik = icerik;
            UserId = userId;
            Oluşturan = olusturan;
            KategoriId = kategoriId;
            ResimId = resimId;
        }

        public string Baslik { get; set; }
        public string Icerik { get; set; }
        
        public Guid KategoriId { get; set; }
        public Guid? ResimId { get; set; }
        public Resim Resim { get; set; }
        public Guid UserId { get; set; }
        public Kategori Kategori { get; set; }
        public AppUser User { get; set; }


    }
}
