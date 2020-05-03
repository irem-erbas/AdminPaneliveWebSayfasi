using AdminPaneliveWebSayfasi.Models.DataContext;
using AdminPaneliveWebSayfasi.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AdminPaneliveWebSayfasi.Controllers
{
    public class KimlikController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext(); //veri tabanının bir örneğini oluşturdum.
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
            //Kimlik tablosundaki verileri çekerek,Index viewe gönderdim. ToList() komutu entity frameworkte veri çekmeye yarar.
        }



        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]  //view sayfasında @Html.AntiForgeryToken() buna karşılık olarak controllerda da bu kod satırını eklemek gerekir. url'lerin gönderilmesinde güvenkik açıklarına karşı kullanılır.
        [ValidateInput(false)] //ckedıtor kullandığım için validateınputu false yapmam gerekiyor.
        public ActionResult Edit(int id, Kimlik kimlik, HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid) //model doğrulandıysa
            {
                var k = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
                //veri tabanındaki id ile bizim seçtiğimiz id eşitse,eşleşen ilk kaydı getirecek.

                if (LogoURL != null) //gelen logourl boş değilse;
                {
                    if (System.IO.File.Exists(Server.MapPath(k.LogoURL))) //eğet dosya varsa
                    {
                        System.IO.File.Delete(Server.MapPath(k.LogoURL)); 
                        //dosyayı silicem. Çünkü resmi güncellediğimde eski resmin klasörümden silinmesini istiyorum.
                        
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    string logoname = LogoURL.FileName + imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Kimlik/" + logoname); //Uploads klasörümün altına resmi kaydetsin.

                    k.LogoURL = "/Uploads/Kimlik/" + logoname;
                }
                k.Title = kimlik.Title;
                k.Keywords = kimlik.Keywords;
                k.Description = kimlik.Description;
                k.Unvan = kimlik.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(kimlik);

        }

    }
}
