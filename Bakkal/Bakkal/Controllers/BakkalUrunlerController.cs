using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;

namespace Bakkal.Controllers
{
    public class BakkalUrunlerController : Controller
    {
        Model1 db = new Model1();
        Urunler ur = new Urunler();

        // GET: BakkalUrunler
        public ActionResult Index()
        {
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            
            return View(db.Urunler.Where(x=>x.Bakkal_Id==b).ToList());
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(int id)
        {
            List<SelectListItem> kategoriler =
                (from i in db.Urunler.ToList()
                 select new SelectListItem
                 {
                     Text = i.UrunKategorisi,
                     Value = i.UrunKategorisi
                 }).ToList();
            kategoriler = kategoriler.GroupBy(x => x.Text).Select(x => x.First()).ToList();
            ViewBag.kat = kategoriler;

            var deger = db.Urunler.Find(id);
            return View("Getir", deger);
        }

        public ActionResult Guncelle(Urunler model)
        {
            var gun = db.Urunler.Find(model.UrunId);
            gun.UrunKategorisi = model.UrunKategorisi;
            gun.UrunAdi = model.UrunAdi;
            gun.UrunFiyati = model.UrunFiyati;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}