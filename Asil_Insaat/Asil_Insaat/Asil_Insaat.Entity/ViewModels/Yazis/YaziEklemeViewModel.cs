using Asil_Insaat.Entity.ViewModels.Kategoris;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Yazis
{
    public class YaziEklemeViewModel
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public Guid KategoriId { get; set; }

        public IFormFile Fotograf { get; set; }

        public IList<KategoriViewModel> Kategoris { get; set; }
    }
}
