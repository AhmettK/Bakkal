using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakkal.Models;

namespace WebApplication1.Controllers
{
    public class SignUpController : Controller
    {
        Model1 db = new Model1();

        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        Musteri mus = new Musteri();
        Login log = new Login();

        [HttpPost]
        public ActionResult Index(Musteri model)
        {
            mus.KullaniciAdi = model.KullaniciAdi;
            mus.Sifre = model.Sifre;
            mus.Adres = model.Adres;
            mus.Telefon = model.Telefon;
            mus.Mail = model.Mail;
            mus.Tc = model.Tc;

            log.KullaniciAdi = mus.KullaniciAdi;
            log.Sifre = mus.Sifre;

            db.Musteri.Add(mus);
            db.Login.Add(log);
            db.SaveChanges();

            string success = "Başarıyla üye oldunuz";
            ViewBag.suc = success;

            return View(); ;

        }

    }
}