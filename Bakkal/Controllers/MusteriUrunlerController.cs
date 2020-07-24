using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class MusteriUrunlerController : Controller
    {
        Model1 db = new Model1();
        

        // GET: MusteriUrunler


        public ActionResult Index(Urunler ka)
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

            var urunler = db.Urunler.ToList();
            ViewBag.urun = urunler;

            if (ka.UrunKategorisi == "Ev/Kişisel İhtiyaçlar")
            {
                var t = db.Database.SqlQuery<Urunler>("select *from Urunler where UrunKategorisi='Ev/Kişisel İhtiyaçlar'").ToList();
                ViewBag.urun = t;
            }
            else if (ka.UrunKategorisi == "İçecek")
            {
                var t = db.Database.SqlQuery<Urunler>("select *from Urunler where UrunKategorisi='İçecek'").ToList();
                ViewBag.urun = t;
            }
            else if (ka.UrunKategorisi == "Atıştırmalık")
            {
                var t = db.Database.SqlQuery<Urunler>("select *from Urunler where UrunKategorisi='Atıştırmalık'").ToList();
                ViewBag.urun = t;
            }
            else if (ka.UrunKategorisi == "Gıda Maddeleri")
            {
                var t = db.Database.SqlQuery<Urunler>("select *from Urunler where UrunKategorisi='Gıda Maddeleri'").ToList();
                ViewBag.urun = t;
            }

            return View();
        }


    }
}