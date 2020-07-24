using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;
using System.Data.SqlClient;

namespace Bakkal.Controllers
{
    public class SepetController : Controller
    {
        Model1 db = new Model1();
        Sepet sep = new Sepet();
        
        // GET: Sepet
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);
            //var code = db.Siparis.Where(x => x.MusteriId == b).Select(x => x.Kod).FirstOrDefault();
            var order = db.Siparis.Where(x => x.MusteriId == b);
            var code = -1;
            var onay = 0;
            foreach (var item in order)
            {
                code = item.Kod;
                onay = item.SiparisId;
            }
            
            if (code==0)
            {
                double y = db.Sepet.Where(x => x.MusteriId == b).Sum(x => x.UrunFiyati);
                ViewBag.tutar = y;

                var z = db.Sepet.Select(x => x.Bakkal_Id).Distinct().ToList();
                int uzunluk = z.Count();
                ViewBag.u = uzunluk;

                var bak = db.Bakkallar.ToList();
                if (z[0] == 1)
                {
                    int ucret = bak[0].SiparisUcreti;
                    ViewBag.uc = ucret;
                    double toplam = y + ucret;
                    string toplams = toplam.ToString().Replace(",", ".");
                    ViewBag.top = toplams;
                }
                if (z[0] == 3)
                {
                    int ucret = bak[1].SiparisUcreti;
                    ViewBag.uc = ucret;
                    double toplam = y + ucret;
                    string toplams = toplam.ToString().Replace(",", ".");
                    ViewBag.top = toplams;
                }
                if (z[0] == 4)
                {
                    int ucret = bak[2].SiparisUcreti;
                    ViewBag.uc = ucret;
                    double toplam = y + ucret;
                    string toplams = toplam.ToString().Replace(",", ".");
                    ViewBag.top = toplams;
                }
                //var onay = db.Siparis.Where(x => x.MusteriId == b).Select(x => x.SiparisId).FirstOrDefault();
                ViewBag.onay = onay;
                return View(db.Sepet.Where(x => x.MusteriId == b).ToList());
            }

            else
            {
                return View(db.Sepet.Where(x=>x.MusteriId==0).ToList());
            }
        }

        public ActionResult Sec(int id)
        {
            Siparis temp = new Siparis();

            if (Session["userid"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            string a = Session["userid"].ToString();
            int b = Convert.ToInt16(a);

            var deger = db.Urunler.Find(id);
            //var sip = db.Siparis.Where(x => x.MusteriId == b).Select(x => x.SiparisId).FirstOrDefault();
            var sip = 0;
            foreach (var item in db.Siparis)
            {
                sip = item.SiparisId;
            }
            sep.SiparisId = sip;
            sep.MusteriId = b;
            sep.Bakkal_Id = deger.Bakkal_Id;
            sep.UrunAdi = deger.UrunAdi;
            sep.UrunFiyati = deger.UrunFiyati;
            sep.UrunId = deger.UrunId;
            deger.Stok = deger.Stok - 1;
            
            db.Sepet.Add(sep);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }
        
        public ActionResult Arttir(int id)
        {
            var urun = db.Sepet.Find(id);

            sep.SiparisId = urun.SiparisId;
            sep.MusteriId = urun.MusteriId;
            sep.Bakkal_Id = urun.Bakkal_Id;
            sep.UrunAdi = urun.UrunAdi;
            sep.UrunFiyati = urun.UrunFiyati;
            sep.UrunId = urun.UrunId;

            var depo = db.Urunler.Find(urun.UrunId);
            depo.Stok = depo.Stok - 1;

            db.Sepet.Add(sep);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Sepet.Find(id);
            var mal = db.Urunler.Find(urun.UrunId);
            mal.Stok = mal.Stok + 1;
            db.Sepet.Remove(urun);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Onay(int id,double para)
        {
            var iki = db.Siparis.Find(id);
            iki.Kod = 1;
            iki.Para = para;

            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=Bakkalla;Integrated Security=True");
            baglanti.Open();

            string kopya = "SET IDENTITY_INSERT Yeni ON" +
                " INSERT INTO Yeni (SepetId, SiparisId, MusteriId, Bakkal_Id, UrunAdi, UrunFiyati, UrunId)" +
                " SELECT SepetId, SiparisId, MusteriId, Bakkal_Id, UrunAdi, UrunFiyati, UrunId from Sepet" +
                " SET IDENTITY_INSERT Yeni OFF";
            string temiz = "DELETE FROM Sepet";

            SqlCommand komut = new SqlCommand(kopya, baglanti);
            komut.ExecuteNonQuery();
            SqlCommand query = new SqlCommand(temiz, baglanti);
            query.ExecuteNonQuery();
            baglanti.Close();
            db.SaveChanges();
            return RedirectToAction("Index", "MusteriHome");
        }
    }
}