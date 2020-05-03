using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPaneliveWebSayfasi.Models.Model
{
    [Table("Blog")]
    public class Blog
    {
        public int BlogId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string ResimURL { get; set; }

        //Her blog bir kategoriye aittir. Bu yüzden one to many ilişkisi vardır. Her kategorinin bir blog yazısı olmak zorunda değil. Eğer öyle olsaydı many to many bir ilişki olurdu.
        //Bu yüzden blog tablosu kategori tablosu ile ilişkili olmalıdır.
        public int? KategoriId { get; set; }  //nullable
        public Kategori Kategori { get; set; }
        //public ICollection<Yorum> Yorums { get; set; }
    }
}