using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class MusteriBakkalController : Controller
    {
        Model1 db = new Model1();
        Bakkallar bak = new Bakkallar();
        Urunler ur = new Urunler();
        Siparis sip = new Siparis();
        // GET: Bakkal
        public ActionResult Index()
        {
            var bakkali = db.Bakkallar.ToList();
            ViewBag.bak = bakkali;
            return View();
        }


        public ActionResult Getir(int id)
        {
            ViewBag.aydi = id;
            var urun = db.Urunler.Where(x => x.Bakkal_Id == id).ToList();
            ViewBag.tablo = urun;

            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);

            string c = Session["usertel"].ToString();
            long d = long.Parse(c);

            var ad = db.Bakkallar.Where(x => x.Bakkal_Id == id).Select(x => x.BakkalAdi).FirstOrDefault();

            sip.Bakkal_Id = id;
            sip.MusteriId = b;
            sip.KullaniciAdi = Session["useradi"].ToString();
            sip.Adres = Session["useradres"].ToString();
            sip.Telefon = d;
            sip.BakkalAdi = ad;
            sip.Tarih_Saat = DateTime.Now;
            sip.Kod = 0;
            sip.Para = 0;

            db.Siparis.Add(sip);
            db.SaveChanges();
            return View();
        }


        public ActionResult Goster(int id)
        {
            var urun = db.Urunler.Where(x => x.Bakkal_Id == id).ToList();
            ViewBag.tablo = urun;
            return View();
        }
    }
}