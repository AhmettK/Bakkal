using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class MusteriHomeController : Controller
    {
        Model1 db = new Model1();
        Musteri mus = new Musteri();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
        {
            return View();
        }
        public ActionResult Offer()
        {
            return View();
        }

        public ActionResult MHesap()
        {
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            return View(db.Musteri.Where(x => x.MusteriId == b).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult MHesap(Musteri model)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=Bakkalla;Integrated Security=True");
            baglanti.Open();

            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            string ad = model.KullaniciAdi;
            string sifre = model.Sifre;
            string adres = model.Adres;
            long tel = model.Telefon;
            string mail = model.Mail;

            string kayit = "update Musteri set KullaniciAdi=@KullaniciAdi, Sifre=@Sifre, Adres=@Adres, Telefon=@Telefon, Mail=@Mail where MusteriId=@MusteriId";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@KullaniciAdi", ad);
            komut.Parameters.AddWithValue("@Sifre", sifre);
            komut.Parameters.AddWithValue("@Adres", adres);
            komut.Parameters.AddWithValue("@Telefon", tel);
            komut.Parameters.AddWithValue("@Mail", mail);
            komut.Parameters.AddWithValue("@MusteriId", b);
            komut.ExecuteNonQuery();
            baglanti.Close();
            return RedirectToAction("MHesap");
        }
    }
}