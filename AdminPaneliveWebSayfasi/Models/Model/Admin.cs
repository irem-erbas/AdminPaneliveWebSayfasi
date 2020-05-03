using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPaneliveWebSayfasi.Models.Model
{
    [Table("Admin")] //veri tabanında tablonun adının nasıl görüneceğini belirtiyorum.
    public class Admin
    {
        [Key] //AdminId primary key olmalı.
        public int AdminId { get; set; }
        [Required, StringLength(50, ErrorMessage = "Maksimum 30 Karekter olmalıdır")] //Zorunlu alan,boş geçilemez.
        public string Eposta { get; set; }
        [Required, StringLength(50, ErrorMessage = "Maksimum 20 Karekter olmalıdır")]
        public string Sifre { get; set; }
        public string Yetki { get; set; }
    }
}