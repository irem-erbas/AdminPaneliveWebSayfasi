using AdminPaneliveWebSayfasi.Models.DataContext;
using AdminPaneliveWebSayfasi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPaneliveWebSayfasi.Controllers
{
    public class HakkimizdaController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList(); //Hakkımızda tablosundaki verileri çektik ve viewe gönderdik.
            return View(h);
        }

        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();

            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();

                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                //veri tabanına kaydedildikten sonra(güncelle butonuna bastıktan sonra) hangi sayfaya gideceğini belirtmek gerekiyor. edirectToAction bu işe yarar. 
                return RedirectToAction("Index");
            }

            return View(h);
        }
    }
}