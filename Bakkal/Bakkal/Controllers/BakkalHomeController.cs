using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class BakkalHomeController : Controller
    {
        Model1 db = new Model1();
        Urunler urun = new Urunler();
        Bakkallar bak = new Bakkallar();
        // GET: BakkalHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BHesap()
        {
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            return View(db.Bakkallar.Where(x => x.Bakkal_Id == b).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult BHesap(Bakkallar model)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=Bakkalla;Integrated Security=True");
            baglanti.Open();

            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            string ad = model.BakkalAdi;
            string sifre = model.BakkalSifresi;
            int ucret = model.SiparisUcreti;
            string mail = model.BakkalMail;

            string kayit = "update Bakkallar set BakkalAdi=@BakkalAdi, BakkalSifresi=@BakkalSifresi, SiparisUcreti=@SiparisUcreti, BakkalMail=@BakkalMail where Bakkal_Id=@Bakkal_Id";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@BakkalAdi", ad);
            komut.Parameters.AddWithValue("@BakkalSifresi", sifre);
            komut.Parameters.AddWithValue("@SiparisUcreti", ucret);
            komut.Parameters.AddWithValue("@BakkalMail", mail);
            komut.Parameters.AddWithValue("@Bakkal_Id", b);
            komut.ExecuteNonQuery();
            baglanti.Close();

            return RedirectToAction("BHesap");
        }

        public ActionResult Ekle()
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


            List<SelectListItem> urunler =
                (from i in db.Urunler.ToList()
                 select new SelectListItem
                 {
                     Text = i.UrunAdi
                 }).ToList();
            urunler = urunler.GroupBy(x => x.Text).Select(x => x.First()).ToList();
            ViewBag.ur = urunler;

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Urunler model)
        {
            string id = Session["useradi"].ToString();
            urun.UrunKategorisi = model.UrunKategorisi;
            urun.UrunAdi = model.UrunAdi;
            urun.UrunFiyati = model.UrunFiyati;
            if (id == "Xbakkal")
            {
                urun.Bakkal_Id = 1;
            }
            if (id == "Ybakkal")
            {
                urun.Bakkal_Id = 2;
            }
            if (id == "Zbakkal")
            {
                urun.Bakkal_Id = 3;
            }
            db.Urunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Ekle");
        }
    }
}
